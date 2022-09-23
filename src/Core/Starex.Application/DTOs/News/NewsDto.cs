using System.Text.Json.Serialization;
public class NewsDto
{
    public int Id { get; set; }
    [JsonIgnore]
    public string Image { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public string Desc { get; set; }
}

