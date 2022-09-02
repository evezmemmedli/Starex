using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Domain.Entities
{
    public class Setting :BaseEntity
    {
        public string  Icon { get; set; }
        public string  SocialMedia { get; set; }
        public string  Contact { get; set; }
    }
}
