using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.Id).HasColumnName("OrderId").IsRequired().UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreateDate).IsRequired();

            builder.Property(e => e.OrderStatus).IsRequired();

            builder.Property(e => e.FinalAmount).IsRequired();

            builder.Property(e => e.OrderNumber).IsRequired();

            builder.HasOne(e => e.UserAddress)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.UserAddressId);

            builder.HasMany(e => e.OrderItems)
                .WithOne(e => e.Order)
                .HasForeignKey(e => e.OrderId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}