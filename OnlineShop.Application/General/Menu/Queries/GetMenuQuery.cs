using MediatR;
using OnlineShop.Application.General.Menu.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Menu.Queries
{
    public class GetMenuQuery : IRequest<Result<MenuDto>>
    {
        public int Id { get; set; }
    }
}