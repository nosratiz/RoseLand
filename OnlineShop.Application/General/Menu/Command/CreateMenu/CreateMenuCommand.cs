using MediatR;
using OnlineShop.Application.General.Menu.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Menu.Command.CreateMenu
{
    public class CreateMenuCommand : IRequest<Result<MenuDto>>
    {
        public int? ParentId { get; set; }
       
        public string UniqueName { get; set; }

        public int SortOrder { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Body { get; set; }

        public bool IsPublish { get; set; }
    }
}