using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Authentication.Command;
using OnlineShop.Application.General.AppSetting.Queries;
using OnlineShop.Application.Shop.Cart.Queries;

namespace OnlineShop.UI.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index() => View();


        [HttpGet("signIn")]
        public IActionResult SignIn() => View();

        [HttpGet("signUp")]
        public IActionResult SignUp() => View();

        [HttpGet("forgetPassword")]
        public IActionResult ForgetPassword() => View();

        [HttpGet("ContactUs")]
        public async Task<IActionResult> ContactUs() => View(await _mediator.Send(new GetAppSettingQuery()));


        [HttpGet("verifyAccount/{activeCode}")]
        public async Task<IActionResult> VerifyAccount(Guid activeCode)
         => View(await _mediator.Send(new ConfirmEmailCommand { ActiveCode = activeCode }));



        [HttpGet("Cart")]
        public async Task<IActionResult> Cart() => View(await _mediator.Send(new GetBasketListQueries()));




    }
}