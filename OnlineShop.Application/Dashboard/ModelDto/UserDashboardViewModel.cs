using System.Collections.Generic;
using OnlineShop.Application.Shop.Orders.ModelDto;
using OnlineShop.Application.Users.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Dashboard.ModelDto
{
    public class UserDashboardViewModel
    {
        public Result<UserDto> User { get; set; }

        public List<OrderDto> Orders { get; set; }

        public static UserDashboardViewModel GetUserDashboardViewModel(Result<UserDto> user, List<OrderDto> orders) =>
            new UserDashboardViewModel
            {
                User = user,
                Orders = orders
            };
    }
}