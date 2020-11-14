using System.ComponentModel.DataAnnotations;
using MediatR;
using OnlineShop.Application.Shop.Payment.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.Payment.Command.VerifyPayment
{
    public class VerifyPaymentCommand : IRequest<Result<VerifyPaymentDto>>
    {
        [Required]
        public string Authority { get; set; }
        [Required]
        public long OrderId { get; set; }
        [Required]
        public string Status { get; set; }
    }
}