using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Statistic;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Blog.Command.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly IStatisticService _statisticService;

        public DeleteBlogCommandHandler(ICmsDbContext context, IStatisticService statisticService)
        {
            _context = context;
            _statisticService = statisticService;
        }

        public async Task<Result> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _context.Blogs.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (blog is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.BlogNotFound)));

            _context.Blogs.Remove(blog);

            await _statisticService.UpdateBlogCount(false, cancellationToken);

            var category = await _context.BlogCategories.SingleOrDefaultAsync(x => x.Id == blog.CategoryId, cancellationToken);

            category.BlogCount -= 1;

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.DeleteSuccessfully)));
        }
    }
}