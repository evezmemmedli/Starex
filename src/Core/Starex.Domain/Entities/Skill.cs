using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Domain.Entities
{
    public class Skill:BaseEntity
    {
        public string Name { get; set; }
        public AboutSkill AboutSkill { get; set; }
        public int AboutSkillId { get; set; }
    }
}
