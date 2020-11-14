using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Statistic;

namespace OnlineShop.Application.Common.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly ICmsDbContext _context;

        public StatisticService(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task UpdateProductCount(bool increase,CancellationToken cancellationToken)
        {
            var statistic = await _context.Statistics.FirstOrDefaultAsync(cancellationToken);

            if (increase)
                statistic.TotalProduct += 1;

            else
                statistic.TotalProduct -= 1;

        }

        public async Task UpdateUserCount(bool increase, CancellationToken cancellationToken)
        {
            var statistic = await _context.Statistics.FirstOrDefaultAsync(cancellationToken);

            if (increase)
                statistic.TotalUser += 1;
            else
                statistic.TotalUser -= 1;
        }

        public async Task UpdateBlogCount(bool increase, CancellationToken cancellationToken)
        {
            var statistic = await _context.Statistics.FirstOrDefaultAsync(cancellationToken);

            if (increase)
                statistic.TotalBlog += 1;

            else
                statistic.TotalBlog -= 1;

        }

        public async Task UpdateOrder(bool increase, CancellationToken cancellationToken)
        {
            var statistic = await _context.Statistics.FirstOrDefaultAsync(cancellationToken);

            if (increase)
                statistic.TotalOrder += 1;

            else
                statistic.TotalOrder -= 1;
        }
    }
}