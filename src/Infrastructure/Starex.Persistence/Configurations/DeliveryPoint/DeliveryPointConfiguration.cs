using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starex.Domain.Entities;
public class DeliveryPointConfiguration : IEntityTypeConfiguration<DeliveryPoint>
{
    public void Configure(EntityTypeBuilder<DeliveryPoint> builder)
    {
        builder.Property(p => p.Adress).IsRequired().HasMaxLength(30);
        builder.HasIndex(p => p.Adress).IsUnique();
        builder.Property(p => p.ActiveHour).IsRequired();
    }
}

