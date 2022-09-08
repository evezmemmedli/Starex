using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        public decimal Cashback { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}

