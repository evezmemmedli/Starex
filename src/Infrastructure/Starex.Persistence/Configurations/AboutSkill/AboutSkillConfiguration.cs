using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starex.Domain.Entities;
public class AboutSkillConfiguration : IEntityTypeConfiguration<AboutSkill>
{
    public void Configure(EntityTypeBuilder<AboutSkill> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
    }
}

