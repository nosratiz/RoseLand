using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Persistence.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(e => e.Id).HasColumnName("BlogId").UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.User)
                .WithMany(e => e.Blogs)
                .HasForeignKey(e => e.UserId).IsRequired();

            builder.HasOne(e => e.BlogCategory)
                .WithMany(e => e.Blogs)
                .HasForeignKey(e => e.CategoryId).IsRequired();

            builder.Property(e => e.Title).IsRequired();

            builder.Property(e => e.LongDescription).IsRequired();

            builder.Property(e => e.Slug).IsRequired();

            builder.Property(e => e.CreateDate).HasDefaultValue(DateTime.Now);

            builder.Property(e => e.TotalUniqueView).HasDefaultValue(0);

            builder.Property(e => e.TotalView).HasDefaultValue(0);

        }
    }
}