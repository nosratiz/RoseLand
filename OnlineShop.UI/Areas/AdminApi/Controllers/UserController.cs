using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Authentication.Command;
using OnlineShop.Application.Users.Command.CreateUser;
using OnlineShop.Application.Users.Command.DeleteUser;
using OnlineShop.Application.Users.Command.UpdateUser;

namespace OnlineShop.UI.Areas.AdminApi.Controllers
{
    public class UserController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserCommand createUserCommand)
        {
            var result = await Mediator.Send(createUserCommand);

            return result.ApiResult;
        }


        [HttpPut]
        public async Task<IActionResult> EditUser(UpdateUserCommand updateUserCommand)
        {

            var result = await Mediator.Send(updateUserCommand);

            return result.ApiResult;
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var result = await Mediator.Send(new DeleteUserCommand { Id = id });

            return result.ApiResult;
        }

        [HttpPut("changePassword")]
        public async Task<IActionResult> ChangePassword(ResetPasswordCommand resetPasswordCommand)
        {
            var result = await Mediator.Send(resetPasswordCommand);

            return result.ApiResult;
        }

    }
}