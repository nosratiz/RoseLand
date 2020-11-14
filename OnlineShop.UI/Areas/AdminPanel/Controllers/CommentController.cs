using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Shop.Comments.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class CommentController : BaseAdminController
    {

        [HttpGet]
        public async Task<IActionResult> List(PagingOptions pagingOptions) 
        => View(await Mediator.Send(new GetCommentPagedListQuery
        {
            Page = pagingOptions.Page,
            Limit = pagingOptions.Limit,
            Search = pagingOptions.Search
        }));
    }
}