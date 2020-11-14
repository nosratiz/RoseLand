using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.ProductVariants.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.ProductVariants.Queries
{
    public class GetProductVariantPagedListQuery : PagingOptions, IRequest<Result<PagedList<ProductVariantDto>>>
    {
        public int ProductId { get; set; }
    }
    public class GetProductVariantPagedListQueryHandler : PagingService<ProductVariant>, IRequestHandler<GetProductVariantPagedListQuery, Result<PagedList<ProductVariantDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetProductVariantPagedListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<ProductVariantDto>>> Handle(GetProductVariantPagedListQuery request, CancellationToken cancellationToken)
        {
            var productVariantList = _context.ProductVariants.Where(x => x.ProductId == request.ProductId).Include(x => x.Product);

            var productVariantPagedList = await GetPagedAsync(request.Page, request.Limit, productVariantList);

            return Result<PagedList<ProductVariantDto>>.SuccessFull(productVariantPagedList.MapTo<ProductVariantDto>(_mapper), request);
        }
    }
}