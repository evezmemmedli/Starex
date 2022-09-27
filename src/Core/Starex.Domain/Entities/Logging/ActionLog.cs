using Starex.Domain.Entities.Base;

namespace Starex.Domain.Entities.Logging
{
    public class ActionLog : BaseEntity
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IpAddress { get; set; }
    }
}
