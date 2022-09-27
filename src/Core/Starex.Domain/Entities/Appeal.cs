using Starex.Domain.Entities.Base;
using Starex.Domain.Entities;
public class Appeal : BaseEntity
{
    public string Message { get; set; }
    public string AppUserId { get; set;}
    public AppUser AppUser { get; set;}
}
