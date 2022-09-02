using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class SkillWriteRepository : WriteRepository<Skill>, ISkillWriteRepository
{
    public SkillWriteRepository(StarexDbContext context) : base(context) { }
}
