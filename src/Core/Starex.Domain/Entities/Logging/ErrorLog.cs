using Starex.Domain.Entities.Base;

namespace Starex.Domain.Entities.Logging
{
    public class ErrorLog : BaseEntity
    {
        public string ExceptionCode { get; set; }
        public string? Exception { get; set; }
        public string Message { get; set; }
        public string ErrorPage { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IpAddress { get; set; }
    }
}
