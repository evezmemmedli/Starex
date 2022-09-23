using Starex.Domain.Entities.Base;
using System;

namespace Starex.Domain.Entities
{
    public class FaqQuestion:BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public FAQ Faq { get; set; }
        public int FaqId { get; set; }

    }
}
