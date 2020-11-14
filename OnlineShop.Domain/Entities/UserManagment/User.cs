using System;
using System.Collections.Generic;
using OnlineShop.Common.Enum;
using OnlineShop.Domain.Entities.Shop;
using OnlineShop.Domain.Entities.UserManagment;

namespace OnlineShop.Domain.Entities.UserManagement
{
    public class User
    {
        public User()
        {
            Blogs = new HashSet<Blog>();
            UserTokens = new HashSet<UserToken>();
            OrderItems = new HashSet<OrderItem>();
            UserAddresses = new HashSet<UserAddress>();
            Comments = new HashSet<Comment>();
            UserDiscountCodes = new HashSet<UserDiscountCode>();
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Status Status { get; set; }
        public string PhoneNumber { get; set; }
        public string ConfirmedNumber { get; set; }
        public string Avatar { get; set; }
        public int RoleId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime ExpiredVerification { get; set; }
        public Guid ActivationCode { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsPhoneConfirmed { get; set; }


        public virtual Role Role { get; set; }
        public virtual ICollection<Blog> Blogs { get; }
        public virtual ICollection<UserToken> UserTokens { get; }
        public virtual ICollection<UserAddress> UserAddresses { get; }
        public virtual ICollection<OrderItem> OrderItems { get; }
        public virtual ICollection<Comment> Comments { get; }

        public virtual ICollection<UserDiscountCode> UserDiscountCodes { get; }
    }
}