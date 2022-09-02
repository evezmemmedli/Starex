using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class ServiceReadRepository : ReadRepository<Service>, IServiceReadRepository
{
    public ServiceReadRepository(StarexDbContext context) : base(context) { }
}
