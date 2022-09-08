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
    public class CountryConfiguration :IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(p => p.Name).IsUnique();
            builder.HasIndex(p => p.Flag).IsUnique();
        }
    }
}
