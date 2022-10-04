using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Domain.Entities
{
    public class Package : BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public double DeliveryPrice { get; set; }
        public string Weight { get; set; }
        public bool Payment { get; set; }
        public bool Status { get; set; }
    }
}
