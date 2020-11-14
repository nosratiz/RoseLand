using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.ProductCategories.Command.DeleteCategory
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, Result>
    {
        private readonly ICmsDbContext _context;

        public DeleteProductCategoryCommandHandler(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory =
                await _context.ProductCategories.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

            if (productCategory is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.CategoryNotFound)));

            var categoryIds = await _context.ProductCategories.Where(x => !x.IsDeleted && x.ParentId == request.Id).Select(x => x.Id).ToListAsync(cancellationToken);

            categoryIds.Add(request.Id);

            if (await _context.Products.AnyAsync(x => categoryIds.Contains(x.ProductCategoryId), cancellationToken))
                return Result.Failed(new BadRequestObjectResult(new ApiMessage(ResponseMessage.CategoryInUse)));

            productCategory.IsDeleted = true;

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(ResponseMessage.DeleteSuccessfully));
        }
    }
}