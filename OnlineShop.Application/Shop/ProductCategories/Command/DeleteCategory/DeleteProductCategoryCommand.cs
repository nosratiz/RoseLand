using MediatR;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.ProductCategories.Command.DeleteCategory
{
    public class DeleteProductCategoryCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}