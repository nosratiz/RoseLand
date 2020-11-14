using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.General.BlogCategory.Command.CreateCategory;
using OnlineShop.Application.General.BlogCategory.Command.DeleteCategory;
using OnlineShop.Application.General.BlogCategory.Command.UpdateCategory;
using OnlineShop.Application.General.BlogCategory.ModelDto;

namespace OnlineShop.UI.Areas.AdminApi.Controllers
{
    public class BlogCategoryController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> AddBlogCategory(CreateCategoryCommand createCategory)
        {
            var result = await Mediator.Send(createCategory);


            return result.ApiResult;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteCategoryCommand { Id = id });

            return result.ApiResult;
        }


        [HttpPut]
        public async Task<IActionResult> EditBlogCategory(UpdateCategoryCommand updateBlogCategoryView)
        {
            var result = await Mediator.Send(updateBlogCategoryView);

            return result.ApiResult;
        }
    }
}