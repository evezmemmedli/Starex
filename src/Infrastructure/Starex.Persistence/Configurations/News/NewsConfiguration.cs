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
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Desc).HasMaxLength(5000).IsRequired();
            builder.Property(p => p.Image).IsRequired();
            
        }
    }
}
