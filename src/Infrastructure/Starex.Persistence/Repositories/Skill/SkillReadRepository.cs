using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class SkillReadRepository : ReadRepository<Skill>, ISkillReadRepository
{
    public SkillReadRepository(StarexDbContext context) : base(context) { }
}
