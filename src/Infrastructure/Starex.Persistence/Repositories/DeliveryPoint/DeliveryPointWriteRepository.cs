using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class DeliveryPointWriteRepository : WriteRepository<DeliveryPoint>, IDeliveryPointWriteRepository
{
    public DeliveryPointWriteRepository(StarexDbContext context) : base(context) { }
}
