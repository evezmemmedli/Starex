using AutoMapper;
using Starex.Domain.Entities;
public class CountryMap : Profile
{
    public CountryMap()
    {
        CreateMap<CountryPostDto, Country>();
        CreateMap<Country, CountryDto>();
    }
}

