using MediatR;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Users.Command.UpdateUser
{
    public class UpdateUserCommand : IRequest<Result>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Family { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int RoleId { get; set; }
    }
}