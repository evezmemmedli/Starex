using System.Text.Json.Serialization;

public class AboutDto
{
    public int Id { get; set; }
    [JsonIgnore]
    public string Photo { get; set; }

    public string PhotoUrl { get; set; }
    public string Desc { get; set; }
}

