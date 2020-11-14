using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Dashboard.ModelDto;
using OnlineShop.Application.Shop.BankTransactions.Queries;
using OnlineShop.Application.Shop.Orders.Queries;
using OnlineShop.Application.UserAddress.Queries;
using OnlineShop.Application.Users.Queries;
using OnlineShop.UI.Core;

namespace OnlineShop.UI.Controllers
{
    [Route("[Controller]")]
    [Authorize]
    public class ProfileController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> UserDashboard()
        {
            var user = await Mediator.Send(new GetUserQuery { Id = CurrentUser.UserId });

            var order = await Mediator.Send(new GetOrderListQuery { UserId = CurrentUser.UserId, Limit = 5 });

            return View(UserDashboardViewModel.GetUserDashboardViewModel(user, order));
        }

        [HttpGet("myAddressList")]
        public async Task<IActionResult> MyAddress() => View(await Mediator.Send(new GetAddressListQueries { UserId = CurrentUser.UserId }));

        [HttpGet("addUserAddress")]
        public IActionResult AddUserAddress() => View();

        [HttpGet("editUserAddress/{id}")]
        public async Task<IActionResult> EditUserAddress(int id) => View(await Mediator.Send(new GetUserAddressQuery { Id = id }));

        [HttpGet("edit")]
        public async Task<IActionResult> Edit() => View(await Mediator.Send(new GetUserQuery { Id = CurrentUser.UserId }));

        [HttpGet("MyOrderList")]
        public async Task<IActionResult> MyOrderList([FromQuery] PagingOptions pagingOptions) =>
            View(await Mediator.Send(new GetUserOrderPagedListQuery
            {
                Limit = pagingOptions.Limit,
                Page = pagingOptions.Page
            }));

        [HttpGet("{orderDetail}/{id}")]
        public async Task<IActionResult> OrderDetails(long id) => View(await Mediator.Send(new GetOrderQuery { Id = id }));

        [HttpGet("MyPayments")]
        public async Task<IActionResult> MyPayments([FromQuery] PagingOptions pagingOptions) =>
            View(await Mediator.Send(new GetUserBankTransactionPagedListQuery
            {
                Limit = pagingOptions.Limit,
                Page = pagingOptions.Page
            }));

        [HttpGet("changePassword")]
        public IActionResult ChangePassword() => View();

        [HttpGet("Logout")]
        public async Task<IActionResult> LogOut()
        {
            await AccountManager.SignOut(HttpContext);

            return RedirectToAction("Index", "Home");
        }

    }
}