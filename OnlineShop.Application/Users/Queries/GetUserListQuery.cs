using MediatR;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Users.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Users.Queries
{
    public class GetUserListQuery : PagingOptions, IRequest<Result<PagedList<UserDto>>>
    {

    }

}