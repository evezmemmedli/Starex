using Starex.Domain.Entities.Base;
using System;

namespace Starex.Domain.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string Flag { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
