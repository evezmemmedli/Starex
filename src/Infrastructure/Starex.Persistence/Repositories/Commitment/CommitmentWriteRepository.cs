using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class CommitmentWriteRepository : WriteRepository<Commitment>, ICommitmentWriteRepository
{
    public CommitmentWriteRepository(StarexDbContext context) : base(context) { }
}
