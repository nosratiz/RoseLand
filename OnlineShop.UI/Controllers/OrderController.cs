using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Shop.Orders.Command.CreateOrder;
using OnlineShop.Application.UserAddress.Queries;
using OnlineShop.Common.Helper;

namespace OnlineShop.UI.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class OrderController : BaseController
    {
        [HttpGet("MyOrder")]
        public async Task<IActionResult> MyOrder()
        {
            var userAddress = await Mediator.Send(new GetAddressListQueries { UserId = CurrentUser.UserId });

            return View(userAddress);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand createOrderCommand)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiMessage(ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            var result = await Mediator.Send(createOrderCommand);

            return result.ApiResult;
        }
    }
}
