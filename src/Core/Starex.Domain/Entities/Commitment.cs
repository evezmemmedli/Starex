using Starex.Domain.Entities.Base;
namespace Starex.Domain.Entities
{
    public class Commitment:BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Fullname { get; set; }
        public string IdentityNumber { get; set; }
    }
}
