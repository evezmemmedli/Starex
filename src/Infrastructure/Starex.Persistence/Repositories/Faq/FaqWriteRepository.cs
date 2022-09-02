using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class FaqWriteRepository : WriteRepository<FAQ>, IFaqWriteRepository
{
    public FaqWriteRepository(StarexDbContext context) : base(context) { }
}
