using Starex.Domain.Entities;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
public class AboutSkillReadRepository :ReadRepository<AboutSkill>,IAboutSkillReadRepository
    {
    public AboutSkillReadRepository(StarexDbContext context) : base(context) { }
    }
