using OnlineShop.Application.Shop.Products.ModelDto;
using OnlineShop.Common.Enum;

namespace OnlineShop.Application.Shop.ProductVariants.ModelDto
{
    public class ProductVariantDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public long Price { get; set; }

        public long? DiscountPrice { get; set; }

        public int Count { get; set; }

        public BoxType BoxType { get; set; }
        public string Description { get; set; }

        public virtual ProductDto Product { get; set; }
    }
}