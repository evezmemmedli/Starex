using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starex.Domain.Entities;

public class FaqConfiguration : IEntityTypeConfiguration<FAQ>
{
    public void Configure(EntityTypeBuilder<FAQ> builder)
    {
        builder.Property(p => p.Title).HasMaxLength(30).IsRequired();
        builder.HasIndex(p => p.Title).IsUnique();
    }
}


