using Starex.Domain.Entities.Base;
using System;
namespace Starex.Domain.Entities
{
    public class ReturnPackage:BaseEntity
    {
        public int ReturnetOrderId { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
