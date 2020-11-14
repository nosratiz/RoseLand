using MediatR;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.General.Menu.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Menu.Queries
{
    public class GetMenuListQuery : PagingOptions, IRequest<Result<PagedList<MenuDto>>>
    {

    }
}