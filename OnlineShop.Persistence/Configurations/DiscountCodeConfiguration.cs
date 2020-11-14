using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Persistence.Configurations
{
    public class DiscountCodeConfiguration : IEntityTypeConfiguration<DiscountCode>
    {
        public void Configure(EntityTypeBuilder<DiscountCode> builder)
        {
            builder.Property(e => e.Id).IsRequired().HasColumnName("DiscountCodeId").UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreateDate).IsRequired();

            builder.Property(e => e.Code).IsRequired();

            builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);

            builder.Property(e => e.IsActive).IsRequired().HasDefaultValue(true);

            builder.Property(e => e.Count).IsRequired();

            builder.Property(e => e.Price).IsRequired();

            builder.HasMany(e => e.Orders).WithOne(e => e.DiscountCode).HasForeignKey(e => e.DiscountCodeId);
        }
    }
}