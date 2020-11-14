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
    public class GetMostVisitedBlogListQuery :IRequest<List<BlogDto>>
    {
        
    }

    public class GetMostVisitedBlogListQueryHandler :IRequestHandler<GetMostVisitedBlogListQuery,List<BlogDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetMostVisitedBlogListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BlogDto>> Handle(GetMostVisitedBlogListQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _context.Blogs.Where(x => x.PublishDate.HasValue)
                .OrderByDescending(x => x.TotalUniqueView).ToListAsync(cancellationToken);


            return _mapper.Map<List<BlogDto>>(blogs);
        }
    }
}