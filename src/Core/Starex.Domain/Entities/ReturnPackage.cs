using Starex.Domain.Entities.Base;
using System;
namespace Starex.Domain.Entities
{
    public class ReturnPackage:BaseEntity
    {
        public Order OrderId { get; set; }
    }
}
