using AutoMapper;
using Starex.Domain.Entities;
public class FaqMap:Profile
{
    public FaqMap()
    {
        CreateMap<FaqPostDto,FAQ>();
        CreateMap<FAQ,FaqDto>();
    }
}

