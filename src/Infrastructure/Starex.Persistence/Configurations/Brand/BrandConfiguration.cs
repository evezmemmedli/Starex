using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starex.Domain.Entities;
public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.HasIndex(p => p.Name).IsUnique();
        builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Desc).IsRequired().HasMaxLength(5000);
        builder.Property(p => p.Cashback).HasColumnType("decimal(6,2)").IsRequired();
        builder.Property(p => p.Image).IsRequired();
    }
}

