using AutoMapper;
using Starex.Domain.Entities;
public class AdvantageMap:Profile
{
    public AdvantageMap()
    {
        CreateMap<AdvantagePostDto, Advantage>().ForMember(x => x.Icon, d => d.Ignore());
        CreateMap<Advantage, AdvantageDto>();
    }
}

