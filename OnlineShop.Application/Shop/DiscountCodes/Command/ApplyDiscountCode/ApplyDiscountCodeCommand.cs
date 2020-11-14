using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Orders.ModelDto;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.DiscountCodes.Command.ApplyDiscountCode
{
    public class ApplyDiscountCodeCommand : IRequest<Result<OrderDto>>
    {
        public string Code { get; set; }

    }


    public class ApplyDiscountCodeCommandHandler : IRequestHandler<ApplyDiscountCodeCommand, Result<OrderDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;

        public ApplyDiscountCodeCommandHandler(ICmsDbContext context, IMapper mapper, ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<Result<OrderDto>> Handle(ApplyDiscountCodeCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.OrderByDescending(x => x.CreateDate).FirstOrDefaultAsync(x => x.UserAddress.UserId == int.Parse(_currentUser.UserId)
                                                                          && x.OrderStatus == OrderStatus.InBasket && x.IsDeleted == false, cancellationToken);

            if (order is null)
                return Result<OrderDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.OrderNotFound)));


            var discountCode = await _context.DiscountCodes.SingleOrDefaultAsync(x => x.Code == request.Code && x.IsDeleted == false, cancellationToken);

            order.DiscountPrice = discountCode.Price;

            order.FinalAmount = discountCode.Price > order.FinalAmount ? 0 : order.FinalAmount - discountCode.Price;

            return Result<OrderDto>.SuccessFull(_mapper.Map<OrderDto>(order));
        }
    }
}