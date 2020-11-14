using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Persistence.Configurations
{
    public class OrderStatusHistoryConfiguration : IEntityTypeConfiguration<OrderStatusHistory>
    {
        public void Configure(EntityTypeBuilder<OrderStatusHistory> builder)
        {
            builder.Property(e => e.Id).IsRequired();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.OrderStatus).IsRequired();

            builder.Property(e => e.CreateDate).IsRequired();


            builder.HasOne(e => e.Order)
                .WithMany(e => e.OrderStatusHistories)
                .HasForeignKey(e => e.OrderId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}