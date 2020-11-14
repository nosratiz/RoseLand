using System;

namespace OnlineShop.Application.Shop.BankTransactions.ModelDto
{
    public class BankTransactionDto
    {
        public Guid Id { get; set; }
        public long OrderId { get; set; }
        public string OrderNumber { get; set; }
        public long? RefId { get; set; }

        public int Status { get; set; }
        public long Price { get; set; }
        public string Token { get; set; }
        public DateTime CreateDate { get; set; }
    }
}