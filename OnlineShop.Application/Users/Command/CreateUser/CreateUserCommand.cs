using MediatR;
using OnlineShop.Application.Users.ModelDto;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Users.Command.CreateUser
{
    public class CreateUserCommand : IRequest<Result<UserDto>>
    {
        public string Name { get; set; }

        public string Family { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Avatar { get; set; }

        public int RoleId { get; set; }
    }
}