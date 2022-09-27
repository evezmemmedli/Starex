using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class OrderReadRepository : ReadRepository<Order>,IOrderReadRepository
{
    public OrderReadRepository(StarexDbContext context) : base(context) { }
}

