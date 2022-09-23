using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;
public class AdvantageService : IAdvantageService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    readonly IWebHostEnvironment _env;

    public AdvantageService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _env = env;
    }
    public async Task<AdvantageDto> AddAsync(AdvantagePostDto dto)
    {
        Advantage advantage = _mapper.Map<Advantage>(dto);
        if (!dto.Icon.IsImageOkay(2)) return null;
        advantage.Icon = await dto.Icon.FileCreate(_env.WebRootPath, "images");
        await _unitOfWork.AdvantageWriteRepository.AddAsync(advantage);
        await _unitOfWork.AdvantageWriteRepository.CommitAsync();
        AdvantageDto advantageDto = _mapper.Map<AdvantageDto>(advantage);
        return advantageDto;
    }
    public async Task<AdvantageListDto> GetAll()
    {
        var response = new AdvantageListDto();
        var data = await _unitOfWork.AdvantageReadRepository.GetAll(false).ToListAsync();
        var mappedData = _mapper.Map<List<AdvantageDto>>(data);
        response.AdvantageDtos = mappedData;
        return response;
    }
    public async Task<AdvantageDto> GetByIdAsync(bool tracking, int id)
    {
        Advantage advantage = _unitOfWork.AdvantageReadRepository.Get(tracking, x => x.Id == id).FirstOrDefault();
        if (advantage == null)
            throw new ItemNotFoundException("Item not found");
        AdvantageDto dto = _mapper.Map<AdvantageDto>(advantage);
        return dto;
    }
    public void Remove(int id)
    {
        Advantage advantage = _unitOfWork.AdvantageReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (advantage == null)
            throw new ItemNotFoundException("Item not found");
        _unitOfWork.AdvantageWriteRepository.Remove(advantage);
        _unitOfWork.AdvantageWriteRepository.Commit();
    }
    public void Update(AdvantagePostDto dto, int id)
    {
        Advantage advantage = _unitOfWork.AdvantageReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (advantage == null)
            throw new ItemNotFoundException("Item not found");
        advantage.Title = dto.Title;
        if (dto.Icon != null)
        {
            FileHelpers.FileDelete(_env.WebRootPath, "images", advantage.Icon);
            advantage.Icon = dto.Icon.FileCreate(_env.WebRootPath, "images").Result;
        }
        _unitOfWork.AdvantageWriteRepository.Update(advantage);
        _unitOfWork.AdvantageWriteRepository.Commit();
    }
}

