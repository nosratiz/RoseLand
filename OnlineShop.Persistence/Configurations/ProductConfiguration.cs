using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ProductId").IsRequired().UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired();

            builder.Property(e => e.Image).IsRequired();

            builder.Property(e => e.CreateDate).IsRequired();


            builder.HasMany(e => e.ProductGalleries)
                .WithOne(e => e.Product).HasForeignKey(e => e.ProductId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

        }
    }
}