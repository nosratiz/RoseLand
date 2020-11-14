using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Orders.ModelDto;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.Orders.Queries
{
    public class GetOrderListQuery : IRequest<List<OrderDto>>
    {
        public long UserId { get; set; }

        public int Limit { get; set; }
    }

    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<OrderDto>>
    {

        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Include(x => x.UserAddress)
                .Where(x => !x.IsDeleted && x.UserAddress.UserId == request.UserId).Take(request.Limit).OrderByDescending(x=>x.CreateDate).ToListAsync(cancellationToken);

            return _mapper.Map<List<OrderDto>>(orders);



        }
    }
}