using MediatR;
using OnlineShop.Application.Shop.ProductCategories.ModelDto;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.ProductCategories.Command.CreateCategory
{
    public class CreateProductCategoryCommand : IRequest<Result<ProductCategoryDto>>
    {
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public bool IsActive { get; set; }
    }
}