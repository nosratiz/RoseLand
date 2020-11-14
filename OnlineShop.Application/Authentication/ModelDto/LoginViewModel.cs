using OnlineShop.Application.Authentication.Command;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Application.Authentication.ModelDto
{
    public class LoginViewModel
    {
        public LoginCommand LoginCommand { get; set; }

        public Result<User> User { get; set; }

        public static LoginViewModel GetLoginViewModel(Result<User> user = null, LoginCommand loginCommand = null) =>
            new LoginViewModel
            {
                LoginCommand = loginCommand,
                User = user

            };
    }
}