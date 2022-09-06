
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;

public class ServiceService : IServiceService
{

    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    readonly IWebHostEnvironment _env;

    public ServiceService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _env = env;
    }
    public async Task<ServiceDto> AddAsync(ServicePostDto dto)
    {
        Service service = _mapper.Map<Service>(dto);
        if (!dto.Photo.IsImageOkay(2)) return null;
        service.Photo = await dto.Photo.FileCreate(_env.WebRootPath, "images");
        await _unitOfWork.ServiceWriteRepository.AddAsync(service);
        await _unitOfWork.ServiceWriteRepository.CommitAsync();
        ServiceDto ServiceDto = _mapper.Map<ServiceDto>(service);
        return ServiceDto;
    }

    public async Task<ServiceListDto> GetAll()
    {
        var response = new ServiceListDto();
        var data = await _unitOfWork.ServiceReadRepository.GetAll(false).ToListAsync();
        var mappedData = _mapper.Map<List<ServiceDto>>(data);
        response.ServiceDtos = mappedData;
        return response;
    }

    public async Task<ServiceDto> GetByIdAsync(bool tracking, int id)
    {
        Service service = _unitOfWork.ServiceReadRepository.Get(tracking, x => x.Id == id).FirstOrDefault();
        if (service == null)
            throw new ItemNotFoundException("Item not found");
        ServiceDto dto = _mapper.Map<ServiceDto>(service);
        return dto;
    }

    public void Remove(int id)
    {
        Service service = _unitOfWork.ServiceReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (service == null)
            throw new ItemNotFoundException("Item not found");
        _unitOfWork.ServiceWriteRepository.Remove(service);
        _unitOfWork.ServiceWriteRepository.Commit();
    }

    public void Update(ServicePostDto dto, int id)
    {
        Service service = _unitOfWork.ServiceReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (service == null)
            throw new ItemNotFoundException("Item not found");
        service.Desc = dto.Desc;
        service.Title = dto.Title;
        service.Icon=dto.Icon;
        if (dto.Photo != null)
        {
            FileHelpers.FileDelete(_env.WebRootPath, "images", service.Photo);
            service.Photo = dto.Photo.FileCreate(_env.WebRootPath, "images").Result;
        }
        _unitOfWork.ServiceWriteRepository.Update(service);
        _unitOfWork.ServiceWriteRepository.Commit();
    }
}

