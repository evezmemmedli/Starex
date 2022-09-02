using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class FaqQuestionWriteRepository : WriteRepository<FaqQuestion>, IFaqQuestionWriteRepository
{
    public FaqQuestionWriteRepository(StarexDbContext context) : base(context) { }
}
