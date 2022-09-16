using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Domain.Entities
{
    public class DeliveryPoint : BaseEntity
    {
        public string Adress { get; set; }
        public string ActiveHour { get; set; }
        public List<PoctAdress> PoctAdresses { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
