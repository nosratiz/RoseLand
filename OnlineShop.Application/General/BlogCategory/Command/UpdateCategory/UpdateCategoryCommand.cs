using MediatR;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.BlogCategory.Command.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Result>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Logo { get; set; }

        public string Slug { get; set; }

        public bool IsActive { get; set; }
    }
}