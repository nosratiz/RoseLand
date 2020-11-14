using System;

namespace OnlineShop.Domain.Entities.Shop
{
    public class ProductPriceHistory
    {
        public long Id { get; set; }
        public int ProductVariantId { get; set; }
        public long Price { get; set; }
        public DateTime CreateDateTime { get; set; }

        public virtual ProductVariant ProductVariant { get; set; }
    }
}