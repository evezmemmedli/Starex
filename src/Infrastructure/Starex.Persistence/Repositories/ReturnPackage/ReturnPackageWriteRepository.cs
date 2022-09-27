using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class ReturnPackageWriteRepository : WriteRepository<ReturnPackage>,IReturnPackageWriteRepository
{
    public ReturnPackageWriteRepository(StarexDbContext context) : base(context) { }
}

