using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Domain.Entities.statistic
{
    public class ShopStatistic
    {
        public long Id { get; set; }
        public int Count { get; set; }
        public int ProductVariantId { get; set; }
        public long Price { get; set; }


        public virtual ProductVariant ProductVariant { get; set; }
    }
}