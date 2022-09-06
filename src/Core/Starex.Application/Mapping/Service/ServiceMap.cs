using AutoMapper;
using Starex.Domain.Entities;

public class ServiceMap : Profile
{
    public ServiceMap()
    {
        CreateMap<ServicePostDto, Service>().ForMember(x => x.Photo, d => d.Ignore());
        CreateMap<Service, ServiceDto>();
    }
}

