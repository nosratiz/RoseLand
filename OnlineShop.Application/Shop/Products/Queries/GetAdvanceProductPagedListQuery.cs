using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Products.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;
using Z.EntityFramework.Plus;

namespace OnlineShop.Application.Shop.Products.Queries
{
    public class GetAdvanceProductPagedListQuery : AdvanceFilterProduct, IRequest<Result<PagedList<ProductDto>>>
    {

    }


    public class GetAdvanceProductPagedListQueryHandler : PagingService<Product>, IRequestHandler<GetAdvanceProductPagedListQuery, Result<PagedList<ProductDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetAdvanceProductPagedListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<ProductDto>>> Handle(GetAdvanceProductPagedListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Product> products = _context.Products.IncludeFilter(x =>
                x.ProductVariants.Where(p => p.Price >= request.MinPrice && p.Price <= request.MaxPrice)).Where(x => x.ProductVariants.Any());

            if (request.CategoryId.HasValue)
                products = products.Where(x => x.ProductCategoryId == request.CategoryId.Value);

            products = request.SortOrder.ToLower() switch
            {
                "date" => request.Desc
                    ? products.OrderByDescending(x => x.CreateDate)
                    : products.OrderBy(x => x.CreateDate),
                "price" => request.Desc
                    ? products.OrderByDescending(x => x.ProductVariants.Max(m => m.Price))
                    : products.OrderBy(x => x.ProductVariants.Min(m => m.Price)),
                _ => products.OrderByDescending(x => x.CreateDate)
            };

            var productList = await GetPagedAsync(request.Page, request.Limit, products);

            return Result<PagedList<ProductDto>>.SuccessFull(productList.MapTo<ProductDto>(_mapper), request);
        }
    }
}