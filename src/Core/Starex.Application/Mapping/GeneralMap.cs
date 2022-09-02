using AutoMapper;
using Starex.Domain.Entities;

public class GeneralMap : Profile
{
    public GeneralMap()
    {
        CreateMap<DeliveryPointPostDto, DeliveryPoint>();
        CreateMap<DeliveryPoint, DeliveryPointDto>();
        CreateMap<NewsPostDto, News>().ForMember(x=>x.Image,d=>d.Ignore());
        CreateMap<News, NewsDto>();
    }
}

