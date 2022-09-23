using AutoMapper;
using Starex.Domain.Entities;
public class SkillMap:Profile
{
    public SkillMap()
    {
        CreateMap<SkillPostDto, Skill>();
        CreateMap<Skill, SkillDto>();
    }
}

