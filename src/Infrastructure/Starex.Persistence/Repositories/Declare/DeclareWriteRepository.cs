using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class DeclareWriteRepository : WriteRepository<Declare>, IDeclareWriteRepository
{
    public DeclareWriteRepository(StarexDbContext context) : base(context) { }
}

