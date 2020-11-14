using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Orders.ModelDto;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.Orders.Queries
{
    public class GetUserOrderPagedListQuery : PagingOptions, IRequest<PagedList<OrderDto>>
    {

    }

    public class GetUserOrderPagedListQueryHandler : PagingService<Order>, IRequestHandler<GetUserOrderPagedListQuery, PagedList<OrderDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;

        public GetUserOrderPagedListQueryHandler(ICmsDbContext context, ICurrentUserService currentUser, IMapper mapper)
        {
            _context = context;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<PagedList<OrderDto>> Handle(GetUserOrderPagedListQuery request, CancellationToken cancellationToken)
        {
            var orders = _context.Orders.Where(x => !x.IsDeleted && x.UserAddress.UserId == int.Parse(_currentUser.UserId) && x.OrderStatus != OrderStatus.InBasket).OrderByDescending(x => x.CreateDate);

            var orderPagedList = await GetPagedAsync(request.Page, request.Limit, orders);

            return orderPagedList.MapTo<OrderDto>(_mapper);
        }
    }
}