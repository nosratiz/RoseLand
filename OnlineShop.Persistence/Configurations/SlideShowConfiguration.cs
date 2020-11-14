using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Persistence.Configurations
{
    public class SlideShowConfiguration: IEntityTypeConfiguration<SlideShow>
    {
        public void Configure(EntityTypeBuilder<SlideShow> builder)
        {
            builder.Property(e => e.Id).HasColumnName("SliderId").IsRequired().UseIdentityColumn();

            builder.HasKey(e => e.Id);


            builder.Property(e => e.Image).IsRequired();

            builder.Property(e => e.Name).IsRequired();
        }
    }
}