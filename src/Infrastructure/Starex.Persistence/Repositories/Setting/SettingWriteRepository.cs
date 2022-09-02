using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class SettingWriteRepository : WriteRepository<Setting>, ISettingWriteRepository
{
    public SettingWriteRepository(StarexDbContext context) : base(context) { }
}
