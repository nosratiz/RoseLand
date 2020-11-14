using MediatR;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.Orders.Command.UpdateOrder
{
    public class UpdateOrderStatusCommand : IRequest<Result>
    {
        public long Id { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}