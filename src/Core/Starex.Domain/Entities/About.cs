using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Domain.Entities
{
    public class About :BaseEntity
    {
        public string Photo { get; set; }
        public string Desc { get; set; }
    }
}
