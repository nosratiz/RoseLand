using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.UserManagment;

namespace OnlineShop.Persistence.Configurations
{
    public class UserDiscountCodeConfiguration : IEntityTypeConfiguration<UserDiscountCode>
    {
        public void Configure(EntityTypeBuilder<UserDiscountCode> builder)
        {
            builder.Property(e => e.Id).IsRequired().HasColumnName("UserDiscountCodeId").UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.User)
            .WithMany(e => e.UserDiscountCodes)
            .HasForeignKey(e => e.UserId)
            .IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.DiscountCode)
            .WithMany(e => e.UserDiscountCodes)
            .HasForeignKey(e => e.DiscountCodeId)
            .OnDelete(DeleteBehavior.Cascade);


        }
    }
}