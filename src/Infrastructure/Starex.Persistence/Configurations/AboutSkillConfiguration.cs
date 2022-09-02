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
    public  class AboutSkillConfiguration :IEntityTypeConfiguration<AboutSkill>
    {
        public void Configure(EntityTypeBuilder<AboutSkill> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
        }
    }
}
