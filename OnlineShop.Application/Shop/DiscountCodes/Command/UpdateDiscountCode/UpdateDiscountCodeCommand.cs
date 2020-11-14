using System;
using MediatR;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.DiscountCodes.Command.UpdateDiscountCode
{
    public class UpdateDiscountCodeCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public long Price { get; set; }
        public string Code { get; set; }
        public string StartDate { get; set; }
        public string EndDateTime { get; set; }
        public bool IsActive { get; set; }
        public DiscountType DiscountType { get; set; }
    }
}