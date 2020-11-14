using MediatR;
using OnlineShop.Application.Users.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Users.Queries
{
    public class GetUserQuery : IRequest<Result<UserDto>>
    {
        public long Id { get; set; }
    }
}