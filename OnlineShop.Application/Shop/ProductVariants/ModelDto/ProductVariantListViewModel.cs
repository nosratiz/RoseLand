using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.ProductVariants.ModelDto
{
    public class ProductVariantListViewModel
    {
        public int ProductId { get; set; }

        public Result<PagedList<ProductVariantDto>> ProductVariant { get; set; }

        public static ProductVariantListViewModel GetProductVariantViewModel(Result<PagedList<ProductVariantDto>> productVariant, int productId)
            => new ProductVariantListViewModel
            {
                ProductVariant = productVariant,
                ProductId = productId
            };
    }
}