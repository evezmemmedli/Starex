using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starex.Domain.Entities;
public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
        builder.HasIndex(p => p.Title).IsUnique();
        builder.Property(p => p.Desc).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Icon).IsRequired();
        builder.Property(p => p.Photo).IsRequired();
    }
}

