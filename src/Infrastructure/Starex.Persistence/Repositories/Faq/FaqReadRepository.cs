using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class FaqReadRepository : ReadRepository<FAQ>, IFaqReadRepository
{
    public FaqReadRepository(StarexDbContext context) : base(context) { }
}
