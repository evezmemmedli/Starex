using Starex.Domain.Entities.Base;
using System;

namespace Starex.Domain.Entities
{
    public class Setting :BaseEntity
    {
        public string  Icon { get; set; }
        public string  SocialMedia { get; set; }
        public string  Contact { get; set; }
    }
}
