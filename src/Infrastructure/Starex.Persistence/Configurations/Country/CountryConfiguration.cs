using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starex.Domain.Entities;
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.HasIndex(p => p.Name).IsUnique();
        builder.HasIndex(p => p.Flag).IsUnique();
    }
}

