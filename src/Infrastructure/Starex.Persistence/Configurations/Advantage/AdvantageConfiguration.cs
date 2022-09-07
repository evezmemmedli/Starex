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
    public class AdvantageConfiguration : IEntityTypeConfiguration<Advantage>
    {
        public void Configure(EntityTypeBuilder<Advantage> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Icon).IsRequired();
        }
    }
}
