using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Domain.Entities
{
    public class Order :BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int OrderCode { get; set; } 
        public string OrderLink { get; set; }
        public double Total { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsTaken { get; set; }
        public bool Payment { get; set; }
        public bool IsInForeignStock { get; set; }
        public bool IsInAirport { get; set; }
        public bool isInInsideStock { get; set; }
        public double Weight { get; set; }

    }
}
