using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class DeclareReadRepository : ReadRepository<Declare>, IDeclareReadRepository
{
    public DeclareReadRepository(StarexDbContext context) : base(context) { }
}

