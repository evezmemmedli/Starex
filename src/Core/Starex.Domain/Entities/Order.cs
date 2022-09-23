using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Domain.Entities
{
    public class Order :BaseEntity
    {
        public AppUser UserId { get; set; }
        public int OrderCode { get; set; }
        public string OrderLink { get; set; }
        public int Total { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsTaken { get; set; }
        public bool Payment { get; set; }
        public bool IsInForeignStock { get; set; }
        public bool IsInAirport { get; set; }
        public bool isInInsideStock { get; set; }

    }
}
