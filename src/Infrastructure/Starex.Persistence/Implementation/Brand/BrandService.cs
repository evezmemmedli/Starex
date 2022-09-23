using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;
using Starex.Persistence.Helpers;
public class BrandService : IBrandService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    readonly IWebHostEnvironment _env;
    readonly FileUrlGenerate _fileUrlGenerate;

    public BrandService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env, FileUrlGenerate fileUrlGenerate)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _env = env;
        _fileUrlGenerate = fileUrlGenerate;
    }
    public async Task<BrandDto> AddAsync(BrandPostDto dto)
    {
        Brand brand = _mapper.Map<Brand>(dto);
        if (!dto.Image.IsImageOkay(2)) return null;
        brand.Image = await dto.Image.FileCreate(_env.WebRootPath, "images");
        await _unitOfWork.BrandWriteRepository.AddAsync(brand);
        await _unitOfWork.BrandWriteRepository.CommitAsync();
        BrandDto brandDto = _mapper.Map<BrandDto>(brand);
        return brandDto;
    }
    public async Task<BrandListDto> GetAll()
    {
        var response = new BrandListDto();
        var data = await _unitOfWork.BrandReadRepository.GetAll(false).ToListAsync();
        var mappedData = _mapper.Map<List<BrandDto>>(data);
        mappedData.ForEach(data => data.ImageUrl = _fileUrlGenerate.PhotoUrlGenerate(data.Image));
        response.BrandDtos = mappedData;
        return response;
    }
    public async Task<BrandDto> GetByIdAsync(bool tracking, int id)
    {
        Brand brand = _unitOfWork.BrandReadRepository.Get(tracking, x => x.Id == id).FirstOrDefault();
        if (brand == null)
            throw new ItemNotFoundException("Item not found");
        BrandDto dto = _mapper.Map<BrandDto>(brand);
        dto.ImageUrl = _fileUrlGenerate.PhotoUrlGenerate(dto.Image);
        return dto;
    }
    public void Remove(int id)
    {
        Brand brand = _unitOfWork.BrandReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (brand == null)
            throw new ItemNotFoundException("Item not found");
        _unitOfWork.BrandWriteRepository.Remove(brand);
        _unitOfWork.BrandWriteRepository.Commit();
    }
    public void Update(BrandPostDto dto, int id)
    {
        Brand brand = _unitOfWork.BrandReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (brand == null)
            throw new ItemNotFoundException("Item not found");
        brand.Title = dto.Title;
        brand.Desc = dto.Desc;
        brand.Cashback = dto.Cashback;
        brand.CountryId = dto.CountryId;    
        if (dto.Image != null)
        {
            FileHelpers.FileDelete(_env.WebRootPath, "images", brand.Image);
            brand.Image = dto.Image.FileCreate(_env.WebRootPath, "images").Result;
        }
        _unitOfWork.BrandWriteRepository.Update(brand);
        _unitOfWork.BrandWriteRepository.Commit();
    }
}

