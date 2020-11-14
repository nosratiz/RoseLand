using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Orders.ModelDto;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.Orders.Queries
{
    public class GetUserOrderInBasketQuery : IRequest<Result<OrderDto>>
    {

    }


    public class GetUserOrderInBasketQueryHandler : IRequestHandler<GetUserOrderInBasketQuery, Result<OrderDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetUserOrderInBasketQueryHandler(ICmsDbContext context, ICurrentUserService currentUserService, IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<Result<OrderDto>> Handle(GetUserOrderInBasketQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.Include(x => x.UserAddress).FirstOrDefaultAsync(
                x => !x.IsDeleted && x.OrderStatus == OrderStatus.InBasket &&
                     x.UserAddress.UserId == int.Parse(_currentUserService.UserId), cancellationToken);

            if (order is null)
                return Result<OrderDto>.Failed(new ApiMessage(ResponseMessage.OrderNotFound));


            return Result<OrderDto>.SuccessFull(_mapper.Map<OrderDto>(order));
        }
    }
}