using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class AppealWriteRepository : WriteRepository<Appeal>, IAppealWriteRepository
{
    public AppealWriteRepository(StarexDbContext context) : base(context) { }
}

