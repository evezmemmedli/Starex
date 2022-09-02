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
    public class AboutConfiguration:IEntityTypeConfiguration<About>
    {
       public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(p => p.Desc).HasMaxLength(300).IsRequired();
            builder.Property(p=>p.Photo).IsRequired();
            builder.HasIndex(p=>p.Photo).IsUnique();
        }
    }
}
