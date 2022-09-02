using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class AdvantageWriteRepository : WriteRepository<Advantage>, IAdvantageWriteRepository
{
    public AdvantageWriteRepository(StarexDbContext context) : base(context) { }
}
