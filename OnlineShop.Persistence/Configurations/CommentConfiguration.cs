using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Persistence.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(e => e.Id).IsRequired().HasColumnName("CommentId").UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description).IsRequired();

            builder.Property(e => e.CreateDate).IsRequired();


            builder.HasOne(e => e.Parent).WithMany(e => e.Children).HasForeignKey(e => e.ParentId);

            builder.HasOne(e => e.User).WithMany(e => e.Comments).HasForeignKey(e => e.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Product).WithMany(e => e.Comments).HasForeignKey(e => e.ProductId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}