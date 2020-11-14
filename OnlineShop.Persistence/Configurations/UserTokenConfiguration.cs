using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Persistence.Configurations
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.Property(e => e.Id).HasColumnName("UserTokenId").IsRequired().ValueGeneratedOnAdd();

            builder.Property(e => e.Token).IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(e => e.UserTokens)
                .HasForeignKey(e => e.UserId);
        }
    }
}