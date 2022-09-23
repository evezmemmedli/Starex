using Starex.Domain.Entities;
using Starex.Domain.Entities.Base;
using System;



public class AboutSkill : BaseEntity
{
    public string Name { get; set; }
    public List<Skill> Skills { get; set; }
}

