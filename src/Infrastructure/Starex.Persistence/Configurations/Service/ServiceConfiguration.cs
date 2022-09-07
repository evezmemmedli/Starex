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
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
            builder.HasIndex(p => p.Title).IsUnique();
            builder.Property(p => p.Desc).HasMaxLength(100).IsRequired();
            builder.Property(p=>p.Icon).IsRequired();
            builder.Property(p=>p.Photo).IsRequired();


        }
    }
}
