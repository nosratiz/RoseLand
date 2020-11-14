using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Shop.Orders.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class OrderController : BaseAdminController
    {

        public async Task<IActionResult> List(PagingOptions pagingOptions)

            => View(await Mediator.Send(new GetOrderPagedListQuery
            {
                Page = pagingOptions.Page,
                Limit = pagingOptions.Limit,
                Search = pagingOptions.Search
            }));


        [HttpGet("editOrder")]
        public async Task<IActionResult> EditOrder(long id)
        {
            var result = await Mediator.Send(new GetOrderQuery { Id = id });

            return View(result.ApiResult);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(long id)
        {
            var order = await Mediator.Send(new GetOrderQuery { Id = id });

            return View(order);

        }
    }
}