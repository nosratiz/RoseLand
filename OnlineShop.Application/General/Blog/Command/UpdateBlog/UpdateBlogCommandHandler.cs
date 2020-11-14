using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Blog.Command.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public UpdateBlogCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _context.Blogs.Include(x => x.BlogCategory).SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (blog is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.BlogNotFound)));

            if (blog.CategoryId != request.CategoryId)
            {
                blog.BlogCategory.BlogCount -= 1;

                var category = await _context.BlogCategories.SingleOrDefaultAsync(x => x.Id == request.CategoryId, cancellationToken);

                category.BlogCount += 1;
            }

            _mapper.Map(request, blog);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.UpdateSuccessfully)));
        }
    }
}