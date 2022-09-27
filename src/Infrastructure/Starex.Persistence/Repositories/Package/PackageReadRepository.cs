using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class PackageReadRepository : ReadRepository<Package>, IPackageReadRepository
{
    public PackageReadRepository(StarexDbContext context) : base(context) { }
}

