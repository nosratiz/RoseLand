using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Authentication.Command;
using OnlineShop.Application.UserAddress.Command.CreateUserAddress;
using OnlineShop.Application.UserAddress.Command.DeleteUserAddress;
using OnlineShop.Application.UserAddress.Command.UpdateUserAddress;

namespace OnlineShop.UI.Controllers {
    public class ProfileApiController : BaseUserApiController {

        [HttpPost ("addAddress")]
        public async Task<IActionResult> AddUserAddress (CreateUserAddressCommand createUserAddress) {
            var result = await Mediator.Send (createUserAddress);

            return result.ApiResult;
        }

        [HttpPut ("editAddress")]
        public async Task<IActionResult> EditUserAddress (UpdateUserAddressCommand updateUserAddressCommand) {
            var result = await Mediator.Send (updateUserAddressCommand);

            return result.ApiResult;
        }

        [HttpDelete ("deleteAddress/{id}")]
        public async Task<IActionResult> DeleteAddress (int id) {
            var result = await Mediator.Send (new DeleteUserAddressCommand { Id = id });

            return result.ApiResult;
        }

        [HttpPut ("changePassword")]
        public async Task<IActionResult> ChangePassword (ResetPasswordCommand resetPasswordCommand) {
            var result = await Mediator.Send (resetPasswordCommand);

            return result.ApiResult;
        }

    }
}