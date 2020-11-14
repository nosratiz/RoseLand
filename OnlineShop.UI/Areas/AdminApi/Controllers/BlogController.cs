using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.General.Blog.Command.CreateBlog;
using OnlineShop.Application.General.Blog.Command.DeleteBlog;
using OnlineShop.Application.General.Blog.Command.UpdateBlog;
using OnlineShop.Application.General.Blog.ModelDto;

namespace OnlineShop.UI.Areas.AdminApi.Controllers
{
    public class BlogController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> AddBlog(CreateBlogCommand createBlogCommand)
        {
            var result = await Mediator.Send(createBlogCommand);

            return result.ApiResult;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var result = await Mediator.Send(new DeleteBlogCommand { Id = id });

            return result.ApiResult;
        }

        [HttpPut]
        public async Task<IActionResult> EditBlog(UpdateBlogCommand updateBlogCommand)
        {
            var result = await Mediator.Send(updateBlogCommand);

            return result.ApiResult;
        }
    }
}