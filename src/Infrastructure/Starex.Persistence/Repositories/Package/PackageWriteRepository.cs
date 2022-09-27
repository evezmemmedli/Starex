using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;

public class PackageWriteRepository:WriteRepository<Package>,IPackageWriteRepository
{
    public PackageWriteRepository(StarexDbContext context) : base(context) { }
}

