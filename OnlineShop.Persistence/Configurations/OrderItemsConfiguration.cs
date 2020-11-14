using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Persistence.Configurations
{
    public class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(e => e.Id).HasColumnName("orderItemId").IsRequired().UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreateDate).IsRequired();

            builder.Property(e => e.Price).IsRequired();

            builder.Property(e => e.Count).IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(e => e.OrderItems)
                .HasForeignKey(e => e.UserId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}