using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.General.Blog.Command.DeleteBlog;
using OnlineShop.Application.General.Blog.ModelDto;
using OnlineShop.Application.General.Blog.Queries;
using OnlineShop.Application.General.BlogCategory.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class BlogController : BaseAdminController
    {


        [HttpGet]
        public async Task<IActionResult> BlogList(PagingOptions pagingOptions)
            => View(await Mediator.Send(new GetBlogListQuery
            {
                Limit = pagingOptions.Limit,
                Page = pagingOptions.Page,
                Search = pagingOptions.Search
            }));



    
        [HttpGet("addBlog")]
        public async Task<IActionResult> AddBlog()
        {
            var category = await Mediator.Send(new GetBlogCategoryPagedListQuery { Limit = 100 });

            return View(category.Data.Items);
        }


        [HttpGet("EditBlog")]
        public async Task<IActionResult> EditBlog(int id)
        {
            var result = await Mediator.Send(new GetBlogQuery { Id = id });

            var blogCategories = await Mediator.Send(new GetBlogCategoryPagedListQuery { Limit = 100 });

            return View(UpdateBlogViewModel.GetUpdateBlogViewModel(result, blogCategories.Data.Items));
        }
    }
}