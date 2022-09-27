using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class AppealReadRepository : ReadRepository<Appeal>, IAppealReadRepository
{
    public AppealReadRepository(StarexDbContext context) : base(context) { }
}

