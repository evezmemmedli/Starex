using AutoMapper;
using Starex.Domain.Entities;
public class SettingMap : Profile
{
    public SettingMap()
    {
        CreateMap<SettingPostDto,Setting>();
        CreateMap<Setting,SettingDto>();
    }
}

