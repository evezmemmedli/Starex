using AutoMapper;
using Starex.Domain.Entities;
public class FaqQuestionMap:Profile
{
    public FaqQuestionMap()
    {
        CreateMap<FaqQuestionPostDto, FaqQuestion>();
        CreateMap<FaqQuestion, FaqQuestionDto>();
    }
}

