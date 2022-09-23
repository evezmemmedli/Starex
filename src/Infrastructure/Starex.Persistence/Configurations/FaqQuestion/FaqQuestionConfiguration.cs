using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starex.Domain.Entities;
public class FaqQuestionConfiguration : IEntityTypeConfiguration<FaqQuestion>
{
    public void Configure(EntityTypeBuilder<FaqQuestion> builder)
    {
        builder.Property(p => p.Question).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Answer).HasMaxLength(5000).IsRequired();
    }
}

