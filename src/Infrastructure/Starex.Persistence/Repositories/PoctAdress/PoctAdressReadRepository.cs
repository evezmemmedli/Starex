using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class PoctAdressReadRepository : ReadRepository<PoctAdress>, IPoctAdressReadRepository
{
    public PoctAdressReadRepository(StarexDbContext context) : base(context) { }
}
