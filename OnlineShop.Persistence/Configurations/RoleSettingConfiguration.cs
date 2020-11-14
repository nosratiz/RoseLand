using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Persistence.Configurations
{
    public class RoleSettingConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(e => e.Id).HasColumnName("RoleId").IsRequired();

            builder.Property(e => e.Name).IsRequired();

            
        }
    }
}