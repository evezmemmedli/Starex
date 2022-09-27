
public class OrderGetDto
{
    public string AppUserId { get; set; }
    public int OrderCode { get; set; }
    public string OrderLink { get; set; }
    public int Total { get; set; }
    public bool IsAccepted { get; set; }
    public bool IsTaken { get; set; }
    public bool Payment { get; set; }
    public bool IsInForeignStock { get; set; }
    public bool IsInAirport { get; set; }
    public bool isInInsideStock { get; set; }
    public double Weight { get; set; }
}

