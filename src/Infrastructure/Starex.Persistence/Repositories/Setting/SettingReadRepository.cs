using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class SettingReadRepository : ReadRepository<Setting>, ISettingReadRepository
{
    public SettingReadRepository(StarexDbContext context) : base(context) { }
}
