using AutoMapper;
using Starex.Domain.Entities;
public class AboutSkillMap:Profile
{
    public AboutSkillMap()
    {
        CreateMap<AboutSkillPostDto, AboutSkill>();
        CreateMap<AboutSkill,AboutSkillDto>();
    }
}

