using Starex.Domain.Entities.Base;
public class Declare : BaseEntity
{
    public AppUser AppUser { get; set; }
    public string Brand { get; set; }
    public string Category { get; set; }
    public string File { get; set; }
    public decimal ProductPrice { get; set; }
    public int Count { get; set; }
    public int TrackingId { get; set; }
    public string Comment { get; set; }
    public bool Condition { get; set; }
}
