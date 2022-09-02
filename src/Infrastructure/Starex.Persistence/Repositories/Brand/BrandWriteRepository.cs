using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class BrandWriteRepository : WriteRepository<Brand>, IBrandWriteRepository
{
    public BrandWriteRepository(StarexDbContext context) : base(context) { }
}
