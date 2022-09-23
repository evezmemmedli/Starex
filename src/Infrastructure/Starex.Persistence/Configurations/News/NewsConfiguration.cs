using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starex.Domain.Entities;
public class NewsConfiguration : IEntityTypeConfiguration<News>
{
    public void Configure(EntityTypeBuilder<News> builder)
    {
        builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Desc).HasMaxLength(5000).IsRequired();
        builder.Property(p => p.Image).IsRequired();
    }
}

