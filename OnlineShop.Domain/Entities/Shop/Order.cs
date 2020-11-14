using System;
using System.Collections.Generic;
using OnlineShop.Common.Enum;

namespace OnlineShop.Domain.Entities.Shop
{
    public class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
            OrderStatusHistories = new HashSet<OrderStatusHistory>();
            BankTransactions = new HashSet<BankTransaction>();
        }

        public long Id { get; set; }
        public int UserAddressId { get; set; }
        public int? DiscountCodeId { get; set; }
        public long FinalAmount { get; set; }
        public long DiscountPrice { get; set; }
        public long ShipmentPrice { get; set; }
        public string Description { get; set; }
        public string OrderNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DeliverPeriodTime DeliverPeriodTime { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeliveryDate { get; set; }


        public virtual DiscountCode DiscountCode { get; set; }
        public virtual UserAddress UserAddress { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; }
        public virtual ICollection<OrderStatusHistory> OrderStatusHistories { get; }
        public virtual ICollection<BankTransaction> BankTransactions { get; }

    }
}