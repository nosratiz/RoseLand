using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.ProductCategories.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.ProductCategories.Queries
{
    public class GetProductCategoryPagedListQueryHandler : PagingService<ProductCategory>, IRequestHandler<GetProductCategoryPagedListQuery, Result<PagedList<ProductCategoryDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetProductCategoryPagedListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<ProductCategoryDto>>> Handle(GetProductCategoryPagedListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ProductCategory> productCategories = _context.ProductCategories.Include(x => x.Parent).Where(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(request.Search))
                productCategories = productCategories.Where(x => x.Name.Contains(request.Search));

            var productCategoryPagedList = await GetPagedAsync(request.Page, request.Limit, productCategories);

            return Result<PagedList<ProductCategoryDto>>.SuccessFull(productCategoryPagedList.MapTo<ProductCategoryDto>(_mapper), request);
        }
    }
}