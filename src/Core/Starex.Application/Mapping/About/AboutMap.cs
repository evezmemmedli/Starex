using AutoMapper;
using Starex.Domain.Entities;
public class AboutMap : Profile
{
    public AboutMap()
    {
        CreateMap<AboutPostDto,About>().ForMember(x => x.Photo, d => d.Ignore());
        CreateMap<About, AboutDto>();
    }
}

