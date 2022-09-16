using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Domain.Entities
{
    public class PoctAdress : BaseEntity
    {
        //public PoctAdress()
        //{
        //    AppUsers = new();
        //}
        public string Adress { get; set; }
        public DeliveryPoint DeliveryPoint { get; set; }
        public int DeliveryPointId { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
