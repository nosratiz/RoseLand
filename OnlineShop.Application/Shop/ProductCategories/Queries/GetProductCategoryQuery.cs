using MediatR;
using OnlineShop.Application.Shop.ProductCategories.ModelDto;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.ProductCategories.Queries
{
    public class GetProductCategoryQuery : IRequest<Result<ProductCategoryDto>>
    {
        public int Id { get; set; }
    }
}