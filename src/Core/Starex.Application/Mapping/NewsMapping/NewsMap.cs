using AutoMapper;
using Starex.Domain.Entities;
public class NewsMap:Profile
{
    public NewsMap()
    {
        CreateMap<NewsPostDto, News>().ForMember(x => x.Image, d => d.Ignore());
        CreateMap<News, NewsDto>();
    }
}

