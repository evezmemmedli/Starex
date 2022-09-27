using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;

public class CommitmentReadRepository : ReadRepository<Commitment>, ICommitmentReadRepository
{
    public CommitmentReadRepository(StarexDbContext context) :base(context) { }
}

