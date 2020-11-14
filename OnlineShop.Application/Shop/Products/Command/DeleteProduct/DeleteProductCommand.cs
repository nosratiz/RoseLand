using MediatR;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.Products.Command.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}