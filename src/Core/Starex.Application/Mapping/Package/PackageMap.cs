using AutoMapper;
using Starex.Domain.Entities;

public class PackageMap : Profile
{
    public PackageMap()
    {
        CreateMap<Package, PackageGetDto>();
    }
}

