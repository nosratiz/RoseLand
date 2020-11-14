using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Authentication.Command;
using OnlineShop.Application.General.ContactUs.Command;
using OnlineShop.Application.Users.Command.UpdateProfile;
using OnlineShop.Common.Helper;
using OnlineShop.UI.Core;

namespace OnlineShop.UI.Controllers {
    [Route ("[controller]")]
    [ApiController]
    [EnableCors ("MyPolicy")]
    public class AccountController : BaseController {

        [HttpPost ("SignIn")]
        public async Task<IActionResult> SignIn (LoginCommand loginCommand) {
            var result = await Mediator.Send (loginCommand);

            if (!result.Success)
                return BadRequest (new ApiMessage { Message = result.Message });

            await AccountManager.SignIn (HttpContext, result.Data);

            return Ok (result.Data);
        }

        [HttpPut ("editProfile")]
        public async Task<IActionResult> EditProfile (UpdateProfileCommand updateProfileCommand) {

            if (updateProfileCommand.Id != CurrentUser.UserId)
                return Forbid ();

            var result = await Mediator.Send (updateProfileCommand);

            if (!result.Success)
                return result.ApiResult;

            await AccountManager.SignIn (HttpContext, result.Data);

            return NoContent ();

        }

        [HttpPost ("forgetPassword")]
        public async Task<IActionResult> ForgetPassword (ForgetPasswordCommand forgetPasswordCommand) {

            var result = await Mediator.Send (forgetPasswordCommand);

            return result.ApiResult;

        }

        [HttpPost ("register")]
        public async Task<IActionResult> Register (RegisterCommand registerCommand) {
            var result = await Mediator.Send (registerCommand);

            return result.ApiResult;
        }

        [HttpPost ("ContactUs")]
        public async Task<IActionResult> ContactUs (CreateContactUsCommand createContactUs) {

            var result = await Mediator.Send (createContactUs);

            return result.ApiResult;

        }

    }
}