using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Blog.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Blog.Queries
{
    public class GetBlogBySlugQuery : IRequest<Result<BlogDto>>
    {
        public string Slug { get; set; }
    }


    public class GetBlogBySlugQueryHandler : IRequestHandler<GetBlogBySlugQuery, Result<BlogDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetBlogBySlugQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<BlogDto>> Handle(GetBlogBySlugQuery request, CancellationToken cancellationToken)
        {
            var blog = await _context.Blogs.Include(x => x.User)
            .Include(x => x.BlogCategory)
            .SingleOrDefaultAsync(x => x.Slug == request.Slug, cancellationToken);

            if (blog is null)
                return Result<BlogDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.BlogNotFound)));


            return Result<BlogDto>.SuccessFull(_mapper.Map<BlogDto>(blog));

        }
    }
}