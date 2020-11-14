using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.DiscountCodes.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.DiscountCodes.Queries
{
    public class GetDiscountCodePagedListQuery : PagingOptions, IRequest<Result<PagedList<DiscountCodeDto>>>
    {

    }

    public class GetDiscountCodePagedListQueryHandler : PagingService<DiscountCode>, IRequestHandler<GetDiscountCodePagedListQuery, Result<PagedList<DiscountCodeDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetDiscountCodePagedListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<DiscountCodeDto>>> Handle(GetDiscountCodePagedListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<DiscountCode> discountCodes = _context.DiscountCodes.Where(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(request.Search))
                discountCodes = discountCodes.Where(x => x.Code.Contains(request.Search));

            var disCountCodePagedList = await GetPagedAsync(request.Page, request.Limit, discountCodes);

            return Result<PagedList<DiscountCodeDto>>.SuccessFull(disCountCodePagedList.MapTo<DiscountCodeDto>(_mapper), request);
        }
    }
}