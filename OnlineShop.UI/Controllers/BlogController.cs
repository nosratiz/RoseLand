using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.General.Blog.Queries;

namespace OnlineShop.UI.Controllers
{
    [Route("[controller]")]
    public class BlogController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> BlogList([FromQuery] PagingOptions pagingOptions, string category)
            => View(await Mediator.Send(new GetBlogListQuery
            {
                Limit = 4,
                Page = pagingOptions.Page,
                Search = pagingOptions.Search,
                Category = category
            }));


        [HttpGet("{slug}")]
        public async Task<IActionResult> BlogDetail(string slug) =>
            View(await Mediator.Send(new GetBlogBySlugQuery { Slug = slug }));

    }
}
