using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Statistic;
using OnlineShop.Domain.Entities.statistic;

namespace OnlineShop.Application.Common.Services
{
    public class DailyStatisticService : IDailyStatistic
    {
        private readonly ICmsDbContext _context;

        public DailyStatisticService(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task UpdateRegisterUser(CancellationToken cancellationToken)
        {
            var dailyStat = await _context.DailyStatistics.SingleOrDefaultAsync(x => x.Date == DateTime.Today, cancellationToken);

            if (dailyStat is null)
                await _context.DailyStatistics.AddAsync(new DailyStatistic
                {
                    Date = DateTime.Now,
                    TotalOrder = 0,
                    TotalRevenue = 0,
                    TotalView = 0,
                    RegisterUser = 1
                }, cancellationToken);

            else
                dailyStat.RegisterUser += 1;



        }

        public async Task UpdateOrder(CancellationToken cancellationToken)
        {
            var dailyStat = await _context.DailyStatistics.SingleOrDefaultAsync(x => x.Date == DateTime.Today, cancellationToken);

            if (dailyStat is null)
                await _context.DailyStatistics.AddAsync(new DailyStatistic
                {
                    Date = DateTime.Now,
                    TotalOrder = 1,
                    TotalRevenue = 0,
                    TotalView = 0,
                    RegisterUser = 0
                }, cancellationToken);


            else
                dailyStat.TotalOrder += 1;

        }

        public async Task UpdateRevenue(int revenue, CancellationToken cancellationToken)
        {
            var dailyStat = await _context.DailyStatistics.SingleOrDefaultAsync(x => x.Date == DateTime.Today, cancellationToken);


            if (dailyStat is null)
            {
                await _context.DailyStatistics.AddAsync(new DailyStatistic
                {
                    Date = DateTime.Now,
                    TotalOrder = 1,
                    TotalRevenue = revenue,
                    TotalView = 0,
                    RegisterUser = 0
                }, cancellationToken);
            }
            else
            {
                dailyStat.TotalRevenue += revenue;
                dailyStat.TotalOrder += 1;
            }
        }

        public async Task UpdateView(CancellationToken cancellationToken)
        {
            var dailyStat = await _context.DailyStatistics.SingleOrDefaultAsync(x => x.Date == DateTime.Today, cancellationToken);


            if (dailyStat is null)
                await _context.DailyStatistics.AddAsync(new DailyStatistic
                {
                    Date = DateTime.Now,
                    TotalOrder = 0,
                    TotalRevenue = 0,
                    TotalView = 1,
                    RegisterUser = 0
                }, cancellationToken);

            else
                dailyStat.TotalView += 1;
        }
    }
}