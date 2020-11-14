using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.ProductVariants.ModelDto
{
    public class ProductVariantViewModel
    {
        public int ProductVariantId { get; set; }

        public Result<ProductVariantDto> ProductVariant { get; set; }

        public static ProductVariantViewModel GetProductVariantViewModel(Result<ProductVariantDto> productVariant, int productVariantId) =>
            new ProductVariantViewModel
            {
                ProductVariant = productVariant,
                ProductVariantId = productVariantId
            };
    }
}