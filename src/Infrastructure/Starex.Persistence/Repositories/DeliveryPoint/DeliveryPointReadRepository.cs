using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class DeliveryPointReadRepository : ReadRepository<DeliveryPoint>, IDeliveryPointReadRepository
{
    public DeliveryPointReadRepository(StarexDbContext context) : base(context) { }
}
