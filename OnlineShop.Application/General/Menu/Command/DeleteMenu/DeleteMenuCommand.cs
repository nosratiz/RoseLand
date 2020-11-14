using MediatR;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Menu.Command.DeleteMenu
{
    public class DeleteMenuCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}