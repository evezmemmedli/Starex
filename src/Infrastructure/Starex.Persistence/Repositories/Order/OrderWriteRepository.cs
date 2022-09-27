using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
{
    public OrderWriteRepository(StarexDbContext context) : base(context) { }
}

