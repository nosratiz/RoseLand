using System.Collections.Generic;
using OnlineShop.Application.Shop.ProductCategories.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.Products.ModelDto
{
    public class UpdateProductViewModel
    {
        public Result<ProductDto> ProductResult { get; set; }

        public List<ProductCategoryDto> ProductCategory { get; set; }

        public static UpdateProductViewModel GetUpdateProductViewModel(Result<ProductDto> productResult, List<ProductCategoryDto> productCategory)
            => new UpdateProductViewModel
            {
                ProductResult = productResult,
                ProductCategory = productCategory
            };
    }
}