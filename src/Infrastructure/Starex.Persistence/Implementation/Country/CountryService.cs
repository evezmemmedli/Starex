using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;
public class CountryService : ICountryService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    readonly IWebHostEnvironment _env;

    public CountryService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _env = env;
    }
    public async Task<CountryDto> AddAsync(CountryPostDto dto)
    {
        Country country = _mapper.Map<Country>(dto);
        if (!dto.Flag.IsImageOkay(2)) return null;
        country.Flag = await dto.Flag.FileCreate(_env.WebRootPath, "images");
        await _unitOfWork.CountryWriteRepository.AddAsync(country);
        await _unitOfWork.CountryWriteRepository.CommitAsync();
        CountryDto countryDto = _mapper.Map<CountryDto>(country);
        return countryDto;
    }
    public async Task<CountryListDto> GetAll()
    {
        var response = new CountryListDto();
        var data = await _unitOfWork.CountryReadRepository.GetAll(false, "Brands").ToListAsync();
        var mappedData = _mapper.Map<List<CountryDto>>(data);
        response.CountryDtos = mappedData;
        return response;
    }
    public async Task<CountryDto> GetByIdAsync(bool tracking, int id)
    {
        Country country = _unitOfWork.CountryReadRepository.Get(tracking, x => x.Id == id,"Brands").FirstOrDefault();
        if (country == null)
            throw new ItemNotFoundException("Item not found");
        CountryDto countryDto = _mapper.Map<CountryDto>(country);
        return countryDto;
    }
    public void Remove(int id)
    {
        Country country = _unitOfWork.CountryReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (country == null)
            throw new ItemNotFoundException("Item not found");
        _unitOfWork.CountryWriteRepository.Remove(country);
        _unitOfWork.CountryWriteRepository.Commit();
    }
    public void Update(CountryPostDto dto, int id)
    {
        Country country = _unitOfWork.CountryReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (country == null)
            throw new ItemNotFoundException("Item not found");
        country.Name = dto.Name;
        if (dto.Flag != null)
        {
            FileHelpers.FileDelete(_env.WebRootPath, "images", country.Flag);
            country.Flag = dto.Flag.FileCreate(_env.WebRootPath, "images").Result;
        }
        _unitOfWork.CountryWriteRepository.Update(country);
        _unitOfWork.CountryWriteRepository.Commit();
    }
}

