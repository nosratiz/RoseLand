using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Shop.Orders.Command.UpdateOrder;
using OnlineShop.Application.Shop.Orders.Queries;

namespace OnlineShop.UI.Areas.AdminApi.Controllers
{
    public class OrderController : BaseApiController
    {

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderStatusCommand updateOrder)
        {
            var result = await Mediator.Send(updateOrder);

            return result.ApiResult;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(long id)
        {
            var result = await Mediator.Send(new GetOrderQuery { Id = id });

            return result.ApiResult;
        }


 


    }
}