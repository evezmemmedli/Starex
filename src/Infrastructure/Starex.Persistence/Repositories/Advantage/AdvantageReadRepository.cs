using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class AdvantageReadRepository : ReadRepository<Advantage>, IAdvantageReadRepository
{
    public AdvantageReadRepository(StarexDbContext context) : base(context) { }
}
