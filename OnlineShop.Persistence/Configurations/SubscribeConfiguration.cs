using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Persistence.Configurations
{
    public class SubscribeConfiguration : IEntityTypeConfiguration<Subscribe>
    {
        public void Configure(EntityTypeBuilder<Subscribe> builder)
        {
            builder.Property(e => e.Id).HasColumnName("SubscriberId").IsRequired().UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Email).IsRequired();
        }
    }
}