using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Persistence.Configurations
{
    public class ProductPriceHistoryConfiguration : IEntityTypeConfiguration<ProductPriceHistory>
    {
        public void Configure(EntityTypeBuilder<ProductPriceHistory> builder)
        {
            builder.Property(e => e.Id).IsRequired().UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreateDateTime).IsRequired();

            builder.Property(e => e.Price).IsRequired();

            builder.HasOne(e => e.ProductVariant)
                .WithMany(e => e.ProductPriceHistories)
                .HasForeignKey(e => e.ProductVariantId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}