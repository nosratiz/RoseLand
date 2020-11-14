using MediatR;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.ProductVariants.Command.DeleteCommand
{
    public class DeleteProductVariantCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}