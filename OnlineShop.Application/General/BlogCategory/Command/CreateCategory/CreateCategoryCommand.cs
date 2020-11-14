using MediatR;
using OnlineShop.Application.General.BlogCategory.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.BlogCategory.Command.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Result<BlogCategoryDto>>
    {
        public int? ParentId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Logo { get; set; }

        public string Slug { get; set; }

        public bool IsActive { get; set; }
    }
}