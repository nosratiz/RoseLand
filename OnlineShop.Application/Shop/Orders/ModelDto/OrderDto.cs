using System;
using System.Collections.Generic;
using OnlineShop.Application.Shop.DiscountCodes.ModelDto;
using OnlineShop.Application.UserAddress.ModelDto;
using OnlineShop.Common.Enum;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.Orders.ModelDto
{
    public class OrderDto
    {
        public long Id { get; set; }
        public int UserAddressId { get; set; }
        public long TotalProductPrice { get; set; }
        public long FinalAmount { get; set; }
        public long DiscountPrice { get; set; }
        public long ShipmentPrice { get; set; }
        public string Description { get; set; }
        public string OrderNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DeliverPeriodTime DeliverPeriodTime { get; set; }

        public string CreateDate { get; set; }
        public string DeliveryDate { get; set; }

        public virtual DiscountCodeDto DiscountCode { get; set; }
        public virtual UserAddressDto UserAddress { get; set; }
        public virtual List<OrderItemDto> OrderItems { get; set; }
    }
}