using MediatR;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Menu.Command.UpdateMenu
{
    public class UpdateMenuCommand : IRequest<Result>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public MenuType MenuType { get; set; }

        public string UniqueName { get; set; }

        public int SortOrder { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Body { get; set; }

        public bool IsPublish { get; set; }
    }
}