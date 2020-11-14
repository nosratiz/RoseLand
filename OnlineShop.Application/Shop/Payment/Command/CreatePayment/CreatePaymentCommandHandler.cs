using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Cart;
using OnlineShop.Application.Shop.Payment.ModelDto;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.Payment.Command.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Result<PaymentLinkDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IZarinPalService _zarinPalService;
        private readonly IShoppingCartService _shoppingCartService;

        public CreatePaymentCommandHandler(ICmsDbContext context, ICurrentUserService currentUserService, IZarinPalService zarinPalService, IMediator mediator, IShoppingCartService shoppingCartService)
        {
            _context = context;
            _currentUserService = currentUserService;
            _zarinPalService = zarinPalService;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<Result<PaymentLinkDto>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(x => !x.IsDeleted && (x.OrderStatus == OrderStatus.InBasket || x.OrderStatus == OrderStatus.ReadyForPay) && x.UserAddress.UserId == int.Parse(_currentUserService.UserId) && x.Id == request.OrderId, cancellationToken);

            if (order is null)
                return Result<PaymentLinkDto>.Failed(new ApiMessage(ResponseMessage.OrderNotFound));

            #region Apply Discount Code

            if (!string.IsNullOrWhiteSpace(request.DiscountCode))
            {
                var discountCode = await _context.DiscountCodes.SingleOrDefaultAsync(x => x.Code == request.DiscountCode && x.IsDeleted == false, cancellationToken);

                if (discountCode is null)
                    return Result<PaymentLinkDto>.Failed(new ApiMessage(ResponseMessage.discountCodeNotValid));


                if (discountCode.Count <= 0 && discountCode.EndDateTime <= DateTime.Now)
                    return Result<PaymentLinkDto>.Failed(new ApiMessage(ResponseMessage.discountCodeNotValid));


                order.DiscountPrice = discountCode.Price;

                order.FinalAmount = discountCode.Price > order.FinalAmount ? 0 : order.FinalAmount - discountCode.Price;


            }

            #endregion

            var result = await _zarinPalService.PaymentRequest(request.OrderId, Convert.ToInt32(order.FinalAmount));

            await _context.BankTransactions.AddAsync(new BankTransaction
            {
                CreateDate = DateTime.Now,
                OrderId = order.Id,
                Price = order.FinalAmount,
                Status = result.Status,
                Token = result.Authority
            }, cancellationToken);

            #region Validation Failed in zarin pal gateway


            if (result.Status != (int)ZarinPalStatus.Success)
            {
                var zarinPalStatus = Enum.GetValues(typeof(ZarinPalStatus));

                foreach (int status in zarinPalStatus)
                {
                    if (result.Status == status)
                        return Result<PaymentLinkDto>.Failed(new ApiMessage(EnumConvertor.GetDisplayName((ZarinPalStatus)status)));
                }
            }
            #endregion


            order.OrderStatus = OrderStatus.ReadyForPay;

            await _context.SaveAsync(cancellationToken);

            //clear cookie
            _shoppingCartService.DeleteShoppingCartCookie();

            return Result<PaymentLinkDto>.SuccessFull(new PaymentLinkDto { Link = $"https://www.zarinpal.com/pg/StartPay/{result.Authority}/ZarinGate" });
        }
    }
}