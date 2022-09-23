using System.Text.Json.Serialization;
public class AboutSkillListDto
{
    [JsonPropertyName("aboutSkills")]
    public List<AboutSkillDto> AboutSkillDtos { get; set; }
}

