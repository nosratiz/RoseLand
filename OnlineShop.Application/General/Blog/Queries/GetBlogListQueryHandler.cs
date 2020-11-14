using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Blog.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Blog.Queries
{
    public class GetBlogListQueryHandler : PagingService<Domain.Entities.Blog>, IRequestHandler<GetBlogListQuery, Result<PagedList<BlogDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetBlogListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<BlogDto>>> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Domain.Entities.Blog> blogs = _context.Blogs.Include(x=>x.User).Include(x=>x.BlogCategory);

            if (!string.IsNullOrWhiteSpace(request.Search))
                blogs = blogs.Where(x => x.Title.Contains(request.Search) || x.Description.Contains(request.Search));

            if (!string.IsNullOrWhiteSpace(request.Category))
                blogs = blogs.Where(x => x.BlogCategory.Slug == request.Category);
            

            var blogList = await GetPagedAsync(request.Page, request.Limit, blogs);

            return Result<PagedList<BlogDto>>.SuccessFull(blogList.MapTo<BlogDto>(_mapper), request);

        }
    }
}