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
    public class PoctAdressConfiguration : IEntityTypeConfiguration<PoctAdress>
    {
        public void Configure(EntityTypeBuilder<PoctAdress> builder)
        {
            builder.Property(p => p.Adress).HasMaxLength(100).IsRequired();
            builder.HasIndex(p => p.Adress).IsUnique();
           

        }
    }
}
