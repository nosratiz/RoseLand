using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Persistence.Configurations
{
    public class AppSettingConfiguration : IEntityTypeConfiguration<AppSetting>
    {
        public void Configure(EntityTypeBuilder<AppSetting> builder)
        {
            builder.Property(e => e.Id).HasColumnName("AppSettingId")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(e => e.Title).IsRequired();

            builder.Property(e => e.MaxSizeUploadFile).IsRequired().HasDefaultValue(3);
        }
    }
}