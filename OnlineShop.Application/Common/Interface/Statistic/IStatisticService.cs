using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Common.Interface.Statistic
{
    public interface IStatisticService
    {
        Task UpdateProductCount(bool increase, CancellationToken cancellationToken);

        Task UpdateUserCount(bool increase, CancellationToken cancellationToken);

        Task UpdateBlogCount(bool increase, CancellationToken cancellationToken);

        Task UpdateOrder(bool increase, CancellationToken cancellationToken);
    }
}