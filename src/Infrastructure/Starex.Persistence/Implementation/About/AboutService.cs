using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;
using Starex.Persistence.Helpers;

public class AboutService : IAboutService
{

    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    readonly IWebHostEnvironment _env;
    readonly FileUrlGenerate _fileUrlGenerate;

    public AboutService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env, FileUrlGenerate fileUrlGenerate)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _env = env;
        _fileUrlGenerate = fileUrlGenerate;
    }
    public async Task<AboutDto> AddAsync(AboutPostDto dto)
    {
        About about = _mapper.Map<About>(dto);
        if (!dto.Photo.IsImageOkay(2)) return null;
        about.Photo = await dto.Photo.FileCreate(_env.WebRootPath, "images");
        await _unitOfWork.AboutWriteRepository.AddAsync(about);
        await _unitOfWork.AboutWriteRepository.CommitAsync();
        AboutDto aboutDto = _mapper.Map<AboutDto>(about);
        return aboutDto;
    }

    public async Task<AboutListDto> GetAll()
    {
        var response = new AboutListDto();
        var data = await _unitOfWork.AboutReadRepository.GetAll(false).ToListAsync();
        var mappedData = _mapper.Map<List<AboutDto>>(data);

        mappedData.ForEach(data => data.PhotoUrl = _fileUrlGenerate.PhotoUrlGenerate(data.Photo));

        response.AboutDtos = mappedData;
        return response;
    }

    public async Task<AboutDto> GetByIdAsync(bool tracking, int id)
    {
        About about = _unitOfWork.AboutReadRepository.Get(tracking, x => x.Id == id).FirstOrDefault();
        if (about == null)
            throw new ItemNotFoundException("Item not found");
        AboutDto dto = _mapper.Map<AboutDto>(about);
        dto.PhotoUrl = _fileUrlGenerate.PhotoUrlGenerate(dto.Photo);
        return dto;
    }

    public void Remove(int id)
    {
        About about = _unitOfWork.AboutReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (about == null)
            throw new ItemNotFoundException("Item not found");
        _unitOfWork.AboutWriteRepository.Remove(about);
        _unitOfWork.AboutWriteRepository.Commit();
    }

    public void Update(AboutPostDto dto, int id)
    {
        About about = _unitOfWork.AboutReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (about == null)
            throw new ItemNotFoundException("Item not found");
        about.Desc = dto.Desc;
        if (dto.Photo != null)
        {
            FileHelpers.FileDelete(_env.WebRootPath, "images", about.Photo);
            about.Photo = dto.Photo.FileCreate(_env.WebRootPath, "images").Result;
        }
        _unitOfWork.AboutWriteRepository.Update(about);
        _unitOfWork.AboutWriteRepository.Commit();
    }
}

