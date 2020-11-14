using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Persistence.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(e => e.Id).HasColumnName("NotificationId").IsRequired().UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreateDate).IsRequired();

            builder.Property(e => e.Description).IsRequired();

            builder.Property(e => e.IsRead).IsRequired().HasDefaultValue(false);

            builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}