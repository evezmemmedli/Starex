using System.Text.Json.Serialization;
public class BrandDto
{
    public int Id { get; set; }
    public int CountryId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Desc { get; set; }
    [JsonIgnore]
    public string Image { get; set; }
    public string ImageUrl { get; set; }
    public decimal Cashback { get; set; }
}

