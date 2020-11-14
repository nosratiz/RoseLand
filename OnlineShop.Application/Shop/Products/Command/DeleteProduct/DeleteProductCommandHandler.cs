using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Statistic;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly IStatisticService _statisticService;

        public DeleteProductCommandHandler(ICmsDbContext context, IStatisticService statisticService)
        {
            _context = context;
            _statisticService = statisticService;
        }

        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Include(x => x.ProductCategory).SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (product is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.ProductNotFound)));

            _context.Products.Remove(product);

            product.ProductCategory.ProductCount -= 1;

            await _statisticService.UpdateProductCount(false, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.DeleteSuccessfully)));

        }
    }
}