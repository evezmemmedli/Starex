using AutoMapper;
using Starex.Domain.Entities;
public class DeclareMap : Profile
{
    public DeclareMap()
    {
        CreateMap<DeclarePostDto, Declare>();
        CreateMap<Declare, DeclareGetDto>();
    }
}

