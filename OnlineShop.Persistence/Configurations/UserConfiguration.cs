using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Common.Enum;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id).HasColumnName("UserId").IsRequired().UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.ActivationCode).IsRequired().HasDefaultValue(Guid.NewGuid());

            builder.Property(e => e.IsEmailConfirmed).HasDefaultValue(false);

            builder.Property(e => e.IsPhoneConfirmed).HasDefaultValue(false);

            builder.Property(e => e.RegisterDate).HasDefaultValue(DateTime.Now);

            builder.Property(e => e.ExpiredVerification).HasDefaultValue(DateTime.Now.AddDays(2));

            builder.Property(e => e.Status).IsRequired().HasDefaultValue(Status.Deactivate);

            builder.HasOne(e => e.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.RoleId);

        }
    }
}