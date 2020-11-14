using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Persistence.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(e => e.Id).HasColumnName("menuId").IsRequired().UseIdentityColumn();

            builder.Property(e => e.Controller).IsRequired();

            builder.Property(e => e.Controller).IsRequired();

            builder.Property(e => e.CreationDate).HasDefaultValue(DateTime.Now);

            builder.Property(e => e.IsDeleted).HasDefaultValue(false);

            builder.Property(e => e.Title).IsRequired();

            builder.Property(e => e.TotalUniqueView).HasDefaultValue(0);

            builder.Property(e => e.TotalView).HasDefaultValue(0);

            builder.HasOne(e => e.Parent)
                .WithMany(e => e.Children)
                .HasForeignKey(e => e.ParentId);
        }
    }
}