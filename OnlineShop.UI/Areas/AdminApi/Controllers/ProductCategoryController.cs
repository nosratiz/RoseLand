using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.General.BlogCategory.Command.DeleteCategory;
using OnlineShop.Application.General.BlogCategory.Command.UpdateCategory;
using OnlineShop.Application.Shop.ProductCategories.Command.CreateCategory;
using OnlineShop.Application.Shop.ProductCategories.Command.DeleteCategory;
using OnlineShop.Application.Shop.ProductCategories.Command.UpdateCategory;

namespace OnlineShop.UI.Areas.AdminApi.Controllers
{
    public class ProductCategoryController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateProductCategoryCommand createProductCategory)
        {
            var result = await Mediator.Send(createProductCategory);

            return result.ApiResult;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await Mediator.Send(new DeleteProductCategoryCommand { Id = id });

            return result.ApiResult;
        }


        [HttpPut]
        public async Task<IActionResult> EditCategory(UpdateProductCategoryCommand updateCategoryCommand)
        {
            var result = await Mediator.Send(updateCategoryCommand);

            return result.ApiResult;
        }
    }
}