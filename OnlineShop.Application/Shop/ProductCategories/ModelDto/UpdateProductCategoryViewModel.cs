using System.Collections.Generic;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.ProductCategories.ModelDto
{
    public class UpdateProductCategoryViewModel
    {
        public List<ProductCategoryDto> ProductCategory { get; set; }

        public Result<ProductCategoryDto> ProductCategoryResult { get; set; }

        public static UpdateProductCategoryViewModel GetCategoryViewModel(List<ProductCategoryDto> productCategory, Result<ProductCategoryDto> productCategoryResult)
            => new UpdateProductCategoryViewModel
            {
                ProductCategoryResult = productCategoryResult,
                ProductCategory = productCategory
            };
    }
}