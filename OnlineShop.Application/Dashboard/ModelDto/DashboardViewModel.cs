using System.Collections.Generic;
using OnlineShop.Application.Shop.Orders.ModelDto;
using OnlineShop.Application.Users.ModelDto;

namespace OnlineShop.Application.Dashboard.ModelDto
{
    public class DashboardViewModel
    {
        public StatisticDto StatisticDto { get; set; }

        public List<DailyStatisticDto> DailyStatistic { get; set; }

        public List<OrderDto> Orders { get; set; }

        public List<UserDto> Users { get; set; }

        public static DashboardViewModel DashboardView(StatisticDto statistic, List<DailyStatisticDto> dailyStatistic, List<OrderDto> order, List<UserDto> user)
            => new DashboardViewModel
            {
                DailyStatistic = dailyStatistic,
                Orders = order,
                Users = user,
                StatisticDto = statistic
            };
    }
}