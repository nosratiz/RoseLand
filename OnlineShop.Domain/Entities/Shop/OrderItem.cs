using System;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Domain.Entities.Shop
{
    public class OrderItem
    {
        public long Id { get; set; }
        public int ProductVariantId { get; set; }
        public long? OrderId { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }
        public long Price { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ProductVariant ProductVariant { get; set; }
        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
    }
}