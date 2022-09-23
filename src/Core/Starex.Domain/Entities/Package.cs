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
        public AppUser UserId { get; set; }
        public string TrackingId { get; set; }
        public string Product { get; set; }
        public string DeliveryPrice { get; set; }
        public string Weight { get; set; }
        public string Payment { get; set; }
        public bool Status { get; set; }
    }
}
