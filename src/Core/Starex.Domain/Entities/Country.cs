using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Domain.Entities
{
    public class Country:BaseEntity
    {
        public string Name { get; set; }
        public string Flag { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
