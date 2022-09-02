using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class ServiceWriteRepository : WriteRepository<Service>, IServiceWriteRepository
{
    public ServiceWriteRepository(StarexDbContext context) : base(context) { }
}
