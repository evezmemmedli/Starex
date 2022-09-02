using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Domain.Entities
{
    public class FAQ : BaseEntity
    {
        public string Title { get; set; }
        public List<FaqQuestion> FaqQuestions { get; set; }
    }
}
