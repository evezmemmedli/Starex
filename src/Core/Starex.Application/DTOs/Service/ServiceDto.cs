using System.Text.Json.Serialization;
public class ServiceDto
{
    public string Icon { get; set; }
    public string Desc { get; set; }
    public string Title { get; set; }
    [JsonIgnore]
    public string Photo { get; set; }
    public string PhotoUrl { get; set; }
}

