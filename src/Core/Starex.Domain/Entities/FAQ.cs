using Starex.Domain.Entities.Base;
using System;

namespace Starex.Domain.Entities
{
    public class FAQ : BaseEntity
    {
        public string Title { get; set; }
        public List<FaqQuestion> FaqQuestions { get; set; }
    }
}
