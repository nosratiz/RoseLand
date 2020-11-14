using System;
using OnlineShop.Common.Enum;

namespace OnlineShop.Application.Shop.DiscountCodes.ModelDto
{
    public class DiscountCodeDto
    {
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
    }
}