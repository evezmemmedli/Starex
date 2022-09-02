using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class NewsWriteRepository : WriteRepository<News>, INewsWriteRepository
{
    public NewsWriteRepository(StarexDbContext context) : base(context) { }
}
