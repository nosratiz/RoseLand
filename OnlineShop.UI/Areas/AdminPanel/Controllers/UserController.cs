using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Shop.Comments.Queries;
using OnlineShop.Application.Shop.Orders.Queries;
using OnlineShop.Application.UserAddress.Queries;
using OnlineShop.Application.Users.ModelDto;
using OnlineShop.Application.Users.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class UserController : BaseAdminController
    {

        [HttpGet]
        public async Task<IActionResult> Index(PagingOptions pagingOptions) 
        => View(await Mediator.Send(new GetUserListQuery
        {
            Limit = pagingOptions.Limit,
            Page = pagingOptions.Page,
            Search = pagingOptions.Search
        }));


        [HttpGet("{id}")]
        public async Task<IActionResult> Profile(long id)
        {
            var comments = await Mediator.Send(new GetCommentListQuery { UserId = id }).ConfigureAwait(false);

            var userAddress = await Mediator.Send(new GetAddressListQueries { UserId = id }).ConfigureAwait(false);

            var order = await Mediator.Send(new GetOrderListQuery { UserId = id, Limit = 10 }).ConfigureAwait(false);

            var user = await Mediator.Send(new GetUserQuery { Id = id });

            return View(ProfileViewModel.GetProfileViewModel(user, comments, userAddress, order));
        }

        [HttpGet("addUser")]
        public IActionResult AddUser() => View();



        [HttpGet("editUser")]
        public async Task<IActionResult> EditUser(long id)
        {
            var result = await Mediator.Send(new GetUserQuery { Id = id });

            return View(UpdateUserViewModel.UpdateUserView(result));
        }





    }


}


