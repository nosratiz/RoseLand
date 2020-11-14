using System;
using OnlineShop.Common.Enum;

namespace OnlineShop.Domain.Entities.Shop
{
    public class OrderStatusHistory
    {
        public Guid Id { get; set; }
        public long OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Order Order { get; set; }
    }
}