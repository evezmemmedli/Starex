using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Persistence.Configurations
{
    public class DeliveryPointConfiguration : IEntityTypeConfiguration<DeliveryPoint>
    {
        public void Configure(EntityTypeBuilder<DeliveryPoint> builder)
        {
            builder.Property(p => p.Adress).IsRequired().HasMaxLength(30);
            builder.HasIndex(p => p.Adress).IsUnique();
            builder.Property(p => p.ActiveHour).IsRequired();
        }
    }
}
