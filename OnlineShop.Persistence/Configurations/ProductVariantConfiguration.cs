using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Persistence.Configurations
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.Property(e => e.Id).HasColumnName("productVariantId").IsRequired().UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Price).IsRequired();

            builder.Property(e => e.BoxType).IsRequired();

            builder.Property(e => e.Count).IsRequired();

            builder.HasOne(e => e.Product).WithMany(e => e.ProductVariants).HasForeignKey(e => e.ProductId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.OrderItems)
                .WithOne(e => e.ProductVariant)
                .HasForeignKey(e => e.ProductVariantId).IsRequired();
        }
    }
}