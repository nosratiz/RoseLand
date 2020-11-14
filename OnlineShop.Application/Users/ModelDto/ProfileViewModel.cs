using System.Collections.Generic;
using OnlineShop.Application.Shop.Comments.ModelDto;
using OnlineShop.Application.Shop.Orders.ModelDto;
using OnlineShop.Application.UserAddress.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Users.ModelDto
{
    public class ProfileViewModel
    {
        public Result<UserDto> User { get; set; }

        public List<CommentDto> Comments { get; set; }

        public List<UserAddressDto> UserAddress { get; set; }

        public List<OrderDto> Order { get; set; }

        public static ProfileViewModel GetProfileViewModel(Result<UserDto> userDto, List<CommentDto> comment,
            List<UserAddressDto> userAddress, List<OrderDto> order) => new ProfileViewModel
            {
                UserAddress = userAddress,
                User = userDto,
                Order = order,
                Comments = comment
            };
    }
}