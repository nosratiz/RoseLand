using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.BlogCategory.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.BlogCategory.Queries
{
    public class GetBlogCategoryPagedListQueryHandler : PagingService<Domain.Entities.BlogCategory>, IRequestHandler<GetBlogCategoryPagedListQuery, Result<PagedList<BlogCategoryDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetBlogCategoryPagedListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<BlogCategoryDto>>> Handle(GetBlogCategoryPagedListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Domain.Entities.BlogCategory> category = _context.BlogCategories.Where(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(request.Search))
                category = category.Where(x => x.Name.Contains(request.Search.ToLower()));

            var categoryList = await GetPagedAsync(request.Page, request.Limit, category);

            return Result<PagedList<BlogCategoryDto>>.SuccessFull(categoryList.MapTo<BlogCategoryDto>(_mapper), request);
        }
    }
}