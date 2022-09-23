using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starex.Domain.Entities;
public class PoctAdressConfiguration : IEntityTypeConfiguration<PoctAdress>
{
    public void Configure(EntityTypeBuilder<PoctAdress> builder)
    {
        builder.Property(p => p.Adress).HasMaxLength(100).IsRequired();
        builder.HasIndex(p => p.Adress).IsUnique();
    }
}

