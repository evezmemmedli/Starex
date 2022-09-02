using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Domain.Entities
{
    public class AboutSkill : BaseEntity
    {
        public string Name { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
