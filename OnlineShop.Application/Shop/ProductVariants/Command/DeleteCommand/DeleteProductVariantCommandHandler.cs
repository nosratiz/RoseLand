using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.ProductVariants.Command.DeleteCommand
{
    public class DeleteProductVariantCommandHandler : IRequestHandler<DeleteProductVariantCommand, Result>
    {
        private readonly ICmsDbContext _context;

        public DeleteProductVariantCommandHandler(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(DeleteProductVariantCommand request, CancellationToken cancellationToken)
        {
            var productVariant =
                await _context.ProductVariants.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (productVariant is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.ProductNotFound)));

            if (await _context.OrderItems.AnyAsync(x => x.ProductVariantId == request.Id, cancellationToken))
                return Result.Failed(new BadRequestObjectResult(new ApiMessage(ResponseMessage.ProductInUse)));

            _context.ProductVariants.Remove(productVariant);
            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.DeleteSuccessfully)));
        }
    }
}