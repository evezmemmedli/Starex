using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class AboutReadRepository :ReadRepository<About>, IAboutReadRepository
{
    public AboutReadRepository(StarexDbContext context ):base(context){}
}
