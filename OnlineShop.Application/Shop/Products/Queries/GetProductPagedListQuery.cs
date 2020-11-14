using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Products.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.Products.Queries
{
    public class GetProductPagedListQuery : PagingOptions, IRequest<Result<PagedList<ProductDto>>>
    {

    }

    public class GetProductPagedListQueryHandler : PagingService<Product>, IRequestHandler<GetProductPagedListQuery, Result<PagedList<ProductDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetProductPagedListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<ProductDto>>> Handle(GetProductPagedListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Product> products = _context.Products.Include(x => x.ProductCategory);

            if (!string.IsNullOrWhiteSpace(request.Search))
                products = products.Where(x => x.Name.ToLower().Contains(request.Search.ToLower()) || x.Description.Contains(request.Search));

            var productPagedList = await GetPagedAsync(request.Page, request.Limit, products);

            return Result<PagedList<ProductDto>>.SuccessFull(productPagedList.MapTo<ProductDto>(_mapper), request);
        }
    }
}