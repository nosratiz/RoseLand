using MediatR;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Application.Authentication.Command
{
    public class LoginCommand : IRequest<Result<User>>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}