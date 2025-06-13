
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using supermarket.domain.Entities;

namespace supermarket.ef.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.Property(p => p.Name)
            .HasMaxLength(100);

            builder.Property(p => p.Description)
            .HasMaxLength(500);

            builder.Property(p => p.ImageURL)
            .HasMaxLength(300);

            builder.Property(p => p.Price)
            .HasColumnType("decimal(10, 2)");

            builder.Property(p => p.Offer)
            .HasColumnType("decimal(3, 2)");
        }
    }
}