using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.BlogCategory.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result>
    {
        private readonly ICmsDbContext _context;

        public DeleteCategoryCommandHandler(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.BlogCategories.SingleOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);

            if (category is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.BlogCategoryNotFound)));

            if (await _context.Blogs.AnyAsync(x => x.CategoryId == request.Id, cancellationToken))
                return Result.Failed(new BadRequestObjectResult(new ApiMessage(ResponseMessage.CategoryInUse)));

            category.IsDeleted = true;

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.DeleteSuccessfully)));
        }
    }
}