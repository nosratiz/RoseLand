using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.Orders.Command.CreateOrder
{
    public class CreateOrderCommand : IRequest<Result>
    {
        [Required(ErrorMessage = ResponseMessage.UserAddressIdIsRequired)]
        public int UserAddressId { get; set; }

        [Required(ErrorMessage = ResponseMessage.DeliverDateIsRequired)]
        public DateTime DeliveryDate { get; set; }

        [Required(ErrorMessage = ResponseMessage.PeriodTimeIsRequired)]
        public DeliverPeriodTime DeliverPeriodTime { get; set; }
    }
}