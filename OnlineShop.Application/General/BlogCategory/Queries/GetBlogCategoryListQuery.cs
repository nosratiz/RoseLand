using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.BlogCategory.ModelDto;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.General.BlogCategory.Queries
{
    public class GetBlogCategoryListQuery : IRequest<List<BlogCategoryDto>>
    {

    }

    public class GetBlogCategoryListQueryHandler : IRequestHandler<GetBlogCategoryListQuery, List<BlogCategoryDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetBlogCategoryListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BlogCategoryDto>> Handle(GetBlogCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.BlogCategories.Where(x => !x.IsDeleted && x.IsActive)
                .ToListAsync(cancellationToken);


            return _mapper.Map<List<BlogCategoryDto>>(categories);
        }
    }
}