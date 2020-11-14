using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.General.BlogCategory.ModelDto;
using OnlineShop.Application.General.BlogCategory.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class BlogCategoryController : BaseAdminController
    {


        public async Task<IActionResult> BlogCategoryList(PagingOptions pagingOptions)
            => View(await Mediator.Send(new GetBlogCategoryPagedListQuery
            {
                Page = pagingOptions.Page,
                Limit = pagingOptions.Limit,
                Search = pagingOptions.Search
            }));


        [HttpGet("addBlogCategory")]
        public async Task<IActionResult> AddBlogCategory()
        {
            var result = await Mediator.Send(new GetBlogCategoryPagedListQuery { Page = 1, Limit = 100 });

            return View(CreateCategoryDto.CreateCategory(result.Data.Items));
        }



        [HttpGet("EditBlogCategory")]
        public async Task<IActionResult> EditBlogCategory(int id)
        {
            var result = await Mediator.Send(new GetBlogCategoryQuery { Id = id });

            var blogCategoryList = await Mediator.Send(new GetBlogCategoryPagedListQuery { Page = 1, Limit = 100 });

            return View(UpdateBlogCategoryViewModel.UpdateBlogCategoryView(blogCategoryList.Data.Items, result));
        }






    }
}