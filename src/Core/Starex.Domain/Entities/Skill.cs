using Starex.Domain.Entities.Base;
using System;

namespace Starex.Domain.Entities
{
    public class Skill:BaseEntity
    {
        public string Name { get; set; }
        public AboutSkill AboutSkill { get; set; }
        public int AboutSkillId { get; set; }
    }
}
