using AutoMapper;
using Starex.Domain.Entities;
public class BrandMap :Profile
{
    public BrandMap()
    {
        CreateMap<BrandPostDto, Brand>();
        CreateMap<Brand, BrandDto>();
    }
}

