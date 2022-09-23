using System.Text.Json.Serialization;
public class AboutSkillDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<SkillDto> Skills { get; set; }
}

