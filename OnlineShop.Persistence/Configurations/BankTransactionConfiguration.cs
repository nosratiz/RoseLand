using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Persistence.Configurations
{
    public class BankTransactionConfiguration : IEntityTypeConfiguration<BankTransaction>
    {
        public void Configure(EntityTypeBuilder<BankTransaction> builder)
        {
            builder.Property(e => e.Id).IsRequired().HasColumnName("TransactionId");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreateDate).IsRequired();

            builder.Property(e => e.Price).IsRequired();

            builder.HasOne(e => e.Order)
                .WithMany(e => e.BankTransactions).HasForeignKey(e => e.OrderId).IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}