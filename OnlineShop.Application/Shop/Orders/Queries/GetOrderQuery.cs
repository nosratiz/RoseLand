using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Orders.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.Orders.Queries
{
    public class GetOrderQuery : IRequest<Result<OrderDto>>
    {
        public long Id { get; set; }
    }

    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Result<OrderDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<OrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.Include(x => x.UserAddress).ThenInclude(x => x.User)
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.ProductVariant).ThenInclude(x => x.Product)
                .Include(x => x.DiscountCode)
                .SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id,
                cancellationToken);

            if (order is null)
                return Result<OrderDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.OrderNotFound)));


            return Result<OrderDto>.SuccessFull(_mapper.Map<OrderDto>(order));
        }
    }
}