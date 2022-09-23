using Starex.Domain.Entities.Base;
using System;
namespace Starex.Domain.Entities
{
    public class News :BaseEntity
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
    }
}
