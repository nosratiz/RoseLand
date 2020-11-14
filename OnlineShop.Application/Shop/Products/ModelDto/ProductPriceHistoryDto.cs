using System;

namespace OnlineShop.Application.Shop.Products.ModelDto
{
    public class ProductPriceHistoryDto
    {
        public long Id { get; set; }
        public long Price { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}