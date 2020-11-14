using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OnlineShop.Application.Shop.Orders.Queries;
using OnlineShop.Application.Shop.Payment.Command.CreatePayment;
using OnlineShop.Application.Shop.Payment.Command.VerifyPayment;

namespace OnlineShop.UI.Controllers
{

    [Route("[Controller]")]
    [Authorize]
    public class PaymentController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Payment() => View(await Mediator.Send(new GetUserOrderInBasketQuery()));



        [HttpPost]
        public async Task<IActionResult> Payment(CreatePaymentCommand createPaymentCommand)
        {
            var result = await Mediator.Send(createPaymentCommand);

            if (result.Success == false)
                return View(result);

            return Redirect(result.Data.Link);
        }


        [HttpGet("verification")]
        public async Task<IActionResult> PaymentVerification([FromQuery] VerifyPaymentCommand verifyPaymentCommand)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await Mediator.Send(verifyPaymentCommand);

            return View(result);
        }
    }
}