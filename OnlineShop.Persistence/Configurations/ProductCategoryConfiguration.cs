using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(e => e.Id).IsRequired().HasColumnName("ProductCategoryId").UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired();

            builder.Property(e => e.ProductCount).IsRequired();

            builder.HasMany(e => e.Children)
                .WithOne(e => e.Parent)
                .HasForeignKey(e => e.ParentId);

            builder.HasMany(e => e.Products)
                .WithOne(e => e.ProductCategory)
                .HasForeignKey(e => e.ProductCategoryId)
                .IsRequired();
        }
    }
}