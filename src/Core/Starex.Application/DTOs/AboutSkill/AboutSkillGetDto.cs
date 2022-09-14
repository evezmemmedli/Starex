using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class AboutSkillGetDto
{
    [JsonPropertyName("aboutSkill")]
    public AboutSkillDto AboutSkillDto { get; set; }
}
