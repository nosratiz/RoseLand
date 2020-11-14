using MediatR;
using OnlineShop.Application.Common.Interface.Cart;
using OnlineShop.Application.Shop.DiscountCodes.Command.ApplyDiscountCode;
using OnlineShop.Application.Shop.Payment.ModelDto;
using OnlineShop.Common.Result;


namespace OnlineShop.Application.Shop.Payment.Command.CreatePayment
{
    public class CreatePaymentCommand : IRequest<Result<PaymentLinkDto>>
    {
        public long OrderId { get; set; }
        public string DiscountCode { get; set; }
    }
}