using AutoMapper;
using Starex.Domain.Entities;
public class DeliveryPointMap : Profile
{
    public DeliveryPointMap()
    {
        CreateMap<DeliveryPointPostDto, DeliveryPoint>();
        CreateMap<DeliveryPoint, DeliveryPointDto>();
        
    }
}

