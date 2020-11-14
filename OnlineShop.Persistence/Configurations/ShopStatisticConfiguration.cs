using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.statistic;

namespace OnlineShop.Persistence.Configurations
{
    public class ShopStatisticConfiguration : IEntityTypeConfiguration<ShopStatistic>
    {
        public void Configure(EntityTypeBuilder<ShopStatistic> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ShopStatisticId").IsRequired().UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Price).IsRequired();

            builder.Property(e => e.Count).IsRequired();

            builder.HasOne(e => e.ProductVariant)
                .WithMany(e => e.ShopStatistics)
                .HasForeignKey(e => e.ProductVariantId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}