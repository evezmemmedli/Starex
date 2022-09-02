using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class PoctAdressWriteRepository : WriteRepository<PoctAdress>, IPoctAdressWriteRepository
{
    public PoctAdressWriteRepository(StarexDbContext context) : base(context) { }
}
