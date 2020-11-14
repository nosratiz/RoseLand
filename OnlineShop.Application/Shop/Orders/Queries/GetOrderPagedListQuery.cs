using System.Linq;
using MediatR;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Shop.Orders.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Domain.Entities.Shop;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.Orders.Queries
{
    public class GetOrderPagedListQuery : PagingOptions, IRequest<Result<PagedList<OrderDto>>>
    {

    }
    public class GetOrderPagedListQueryHandler : PagingService<Order>, IRequestHandler<GetOrderPagedListQuery, Result<PagedList<OrderDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderPagedListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<OrderDto>>> Handle(GetOrderPagedListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Order> orders = _context.Orders.Where(x => !x.IsDeleted)
                .Include(x => x.UserAddress).ThenInclude(x => x.User);

            if (!string.IsNullOrWhiteSpace(request.Search))
                orders = orders.Where(x =>
                    x.OrderNumber == request.Search || x.UserAddress.User.Name.ToLower().Contains(request.Search.ToLower()) || x.UserAddress.User.Family.ToLower().Contains(request.Search.ToLower()));

            var orderPagedList = await GetPagedAsync(request.Page, request.Limit, orders);

            return Result<PagedList<OrderDto>>.SuccessFull(orderPagedList.MapTo<OrderDto>(_mapper), request);
        }
    }
}