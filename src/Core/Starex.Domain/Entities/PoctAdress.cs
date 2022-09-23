using Starex.Domain.Entities.Base;
using System;

namespace Starex.Domain.Entities
{
    public class PoctAdress : BaseEntity
    {
        public string Adress { get; set; }
        public DeliveryPoint DeliveryPoint { get; set; }
        public int DeliveryPointId { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
