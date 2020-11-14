using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Persistence.Configurations
{
    public class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategory>
    {
        public void Configure(EntityTypeBuilder<BlogCategory> builder)
        {
            builder.Property(e => e.Id).HasColumnName("CategoryId").UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Parent)
                .WithMany(e => e.Children)
                .HasForeignKey(e => e.ParentId);

            builder.Property(e => e.Name).IsRequired();

            builder.Property(e => e.Slug).IsRequired();

            builder.Property(e => e.IsDeleted).HasDefaultValue(false);

            builder.Property(e => e.IsActive).HasDefaultValue(false);


        }
    }
}