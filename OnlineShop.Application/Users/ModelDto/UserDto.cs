using System;
using System.Collections.Generic;
using OnlineShop.Application.Shop.Comments.ModelDto;
using OnlineShop.Application.Shop.Orders.ModelDto;
using OnlineShop.Application.UserAddress.ModelDto;
using OnlineShop.Common.Enum;

namespace OnlineShop.Application.Users.ModelDto
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string FullName { get; set; }

        public string RoleName { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string ConfirmedNumber { get; set; }
        public bool IsPhoneConfirmed { get; set; }
        public string Avatar { get; set; }
        public DateTime RegisterDate { get; set; }

        public int OrderCount { get; set; }

        public int UserAddressCount { get; set; }

        public int CommentCount { get; set; }


    }
}