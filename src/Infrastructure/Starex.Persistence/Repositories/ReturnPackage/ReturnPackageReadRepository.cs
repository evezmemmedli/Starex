using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class ReturnPackageReadRepository : ReadRepository<ReturnPackage>, IReturnPackageReadRepository
{
    public ReturnPackageReadRepository(StarexDbContext context) : base(context) { }
}

