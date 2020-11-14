using System.Collections.Generic;
using OnlineShop.Common.Enum;
using OnlineShop.Domain.Entities.statistic;

namespace OnlineShop.Domain.Entities.Shop
{
    public class ProductVariant
    {

        public ProductVariant()
        {
            ProductPriceHistories = new HashSet<ProductPriceHistory>();
            OrderItems = new HashSet<OrderItem>();
            ShopStatistics = new HashSet<ShopStatistic>();
        }


        public int Id { get; set; }
        public int ProductId { get; set; }
        public long Price { get; set; }
        public long? DiscountPrice { get; set; }
        public int Count { get; set; }
        public BoxType BoxType { get; set; }
        public string Description { get; set; }



        public virtual Product Product { get; set; }
        public virtual ICollection<ProductPriceHistory> ProductPriceHistories { get; }
        public virtual ICollection<OrderItem> OrderItems { get; }
        public virtual ICollection<ShopStatistic> ShopStatistics { get; }
    }
}