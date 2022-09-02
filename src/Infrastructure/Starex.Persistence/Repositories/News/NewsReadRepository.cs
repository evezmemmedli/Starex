using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class NewsReadRepository : ReadRepository<News>, INewsReadRepository
{
    public NewsReadRepository(StarexDbContext context) : base(context) { }
}
