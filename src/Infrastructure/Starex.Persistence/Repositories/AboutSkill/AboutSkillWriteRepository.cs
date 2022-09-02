using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class AboutSkillWriteRepository : WriteRepository<AboutSkill>, IAboutSkillWriteRepository
{
    public AboutSkillWriteRepository(StarexDbContext context) : base(context) { }
}
