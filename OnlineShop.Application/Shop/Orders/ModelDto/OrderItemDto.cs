using System;
using OnlineShop.Application.Shop.ProductVariants.ModelDto;
using OnlineShop.Application.Users.ModelDto;

namespace OnlineShop.Application.Shop.Orders.ModelDto
{
    public class OrderItemDto
    {
        public long Id { get; set; }
        public int ProductVariantId { get; set; }
        public long? OrderId { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }
        public long Price { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ProductVariantDto ProductVariant { get; set; }
        public virtual UserDto User { get; set; }
    }
}