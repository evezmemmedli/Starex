using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starex.Domain.Entities;
public class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.Property(p => p.SocialMedia).IsRequired();
        builder.Property(p => p.Contact).IsRequired();
        builder.Property(p => p.Icon).IsRequired();
    }
}

