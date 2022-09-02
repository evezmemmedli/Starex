using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class FaqQuestionReadRepository : ReadRepository<FaqQuestion>, IFaqQuestionReadRepository
{
    public FaqQuestionReadRepository(StarexDbContext context) : base(context) { }
}
