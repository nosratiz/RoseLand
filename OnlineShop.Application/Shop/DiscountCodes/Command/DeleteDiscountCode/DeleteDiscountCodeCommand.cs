using MediatR;
using OnlineShop.Application.Shop.DiscountCodes.ModelDto;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.DiscountCodes.Command.DeleteDiscountCode
{
    public class DeleteDiscountCodeCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}