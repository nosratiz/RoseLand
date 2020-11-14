using System;

namespace OnlineShop.Domain.Entities.Shop
{
    public class BankTransaction
    {
        public Guid Id { get; set; }
        public long OrderId { get; set; }
        public long? RefId { get; set; }
        public long Price { get; set; }
        public string Token { get; set; }

        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual Order Order { get; set; }
    }
}