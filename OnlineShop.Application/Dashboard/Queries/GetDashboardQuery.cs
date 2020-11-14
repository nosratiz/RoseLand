using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Dashboard.ModelDto;
using OnlineShop.Application.Shop.Orders.ModelDto;
using OnlineShop.Application.Users.ModelDto;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Dashboard.Queries
{
    public class GetDashboardQuery : IRequest<DashboardViewModel>
    {

    }
    public class GetDashboardQueryHandler : IRequestHandler<GetDashboardQuery, DashboardViewModel>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetDashboardQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DashboardViewModel> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
        {
            var stat = await _context.Statistics.FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

            var dailyStats = await _context.DailyStatistics.OrderByDescending(x => x.Date).Take(5)
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            var users = await _context.Users.OrderByDescending(x => x.RegisterDate).Take(5)
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            var orders = await _context.Orders.Include(x => x.UserAddress).ThenInclude(x => x.User).OrderByDescending(x => x.CreateDate).Take(5)
                .ToListAsync(cancellationToken).ConfigureAwait(false);


            return DashboardViewModel.DashboardView(
                _mapper.Map<StatisticDto>(stat),
                _mapper.Map<List<DailyStatisticDto>>(dailyStats),
                _mapper.Map<List<OrderDto>>(orders),
                _mapper.Map<List<UserDto>>(users));

        }
    }
}