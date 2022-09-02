using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class BrandReadRepository : ReadRepository<Brand>, IBrandReadRepository
{
    public BrandReadRepository(StarexDbContext context) : base(context) { }
}
