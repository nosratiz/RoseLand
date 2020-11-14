using System;
using System.Collections.Generic;
using OnlineShop.Common.Enum;
using OnlineShop.Domain.Entities.UserManagment;

namespace OnlineShop.Domain.Entities.Shop
{
    public class DiscountCode
    {
        public DiscountCode()
        {
            Orders = new HashSet<Order>();
            UserDiscountCodes = new HashSet<UserDiscountCode>();
        }


        public int Id { get; set; }
        public int Count { get; set; }
        public int UsageCount { get; set; }
        public long Price { get; set; }
        public string Code { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDateTime { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DiscountType DiscountType { get; set; }


        public virtual ICollection<Order> Orders { get; }
        public virtual ICollection<UserDiscountCode> UserDiscountCodes { get; }

    }
}