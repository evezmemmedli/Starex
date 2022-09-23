using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class AboutWriteRepository : WriteRepository<About>, IAboutWriteRepository
{
    public AboutWriteRepository(StarexDbContext context) : base(context) { }

}
