using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Domain.Entities
{
    public class Service:BaseEntity
    {
        public string Icon { get; set; }
        public string Desc { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
    }
}
