using MediatR;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Users.Command.DeleteUser
{
    public class DeleteUserCommand : IRequest<Result>
    {
        public long Id { get; set; }
    }
}