using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Authentication.Command;
using OnlineShop.Application.Authentication.ModelDto;
using OnlineShop.UI.Core;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Route("[Area]/[Controller]")]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Login")]
        public IActionResult Login() => View(LoginViewModel.GetLoginViewModel());


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var result = await _mediator.Send(loginViewModel.LoginCommand);

            if (!result.Success)
                return View(LoginViewModel.GetLoginViewModel(result));

            await AccountManager.SignIn(HttpContext, result.Data);

            return RedirectToAction("Index", "Dashboard");

        }


        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await AccountManager.SignOut(HttpContext);

            return RedirectToAction("Login");
        }


        [HttpGet("changePassword")]

        public IActionResult ChangePassword() => View();

    }
}