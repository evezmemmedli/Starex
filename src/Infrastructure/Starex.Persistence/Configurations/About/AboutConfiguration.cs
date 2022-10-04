using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starex.Domain.Entities;
public class AboutConfiguration : IEntityTypeConfiguration<About>
{
    public void Configure(EntityTypeBuilder<About> builder)
    {
        builder.Property(p => p.Desc).HasMaxLength(300).IsRequired();
        builder.Property(p => p.Photo).IsRequired();
        builder.HasIndex(p => p.Photo).IsUnique();
    }
}

