using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Blog.ModelDto;

namespace OnlineShop.Application.General.Blog.Queries
{
    public class GetLatestBlogListQuery : IRequest<List<BlogDto>>
    {
        public int Limit { get; set; }
    }

    public class GetLatestBlogListQueryHandler : IRequestHandler<GetLatestBlogListQuery, List<BlogDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetLatestBlogListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BlogDto>> Handle(GetLatestBlogListQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _context.Blogs
            .OrderByDescending(x => x.CreateDate)
            .Take(request.Limit).ToListAsync(cancellationToken);

            return _mapper.Map<List<BlogDto>>(blogs);
        }
    }
}