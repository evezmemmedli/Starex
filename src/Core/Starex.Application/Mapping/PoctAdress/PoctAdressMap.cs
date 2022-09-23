using AutoMapper;
using Starex.Domain.Entities;
public class PoctAdressMap : Profile
{
    public PoctAdressMap()
    {
        CreateMap<PoctAdressDto, PoctAdress>();
    }
}

