using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Domain.Entities
{
    public class Commitment:BaseEntity
    {
        public AppUser UserId { get; set; }
        public string Fullname { get; set; }
        public string IdentityNumber { get; set; }
    }
}
