using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Persistence.Configurations
{
    public class HtmlPartConfiguration: IEntityTypeConfiguration<HtmlPart>
    {
        public void Configure(EntityTypeBuilder<HtmlPart> builder)
        {
            builder.Property(e => e.Id).HasColumnName("HtmlPartId")
                .IsRequired().UseIdentityColumn();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.UniqueName).IsRequired();

            builder.Property(e => e.Content).IsRequired();

            builder.Property(e => e.Title).IsRequired();

            builder.Property(e => e.IsVital).HasDefaultValue(false);

            builder.Property(e => e.IsPublished).HasDefaultValue(false);
        }
    }
}