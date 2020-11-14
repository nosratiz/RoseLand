using MediatR;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.ProductCategories.Command.UpdateCategory
{
    public class UpdateProductCategoryCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public bool IsActive { get; set; }
    }
}