using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Statistic;
using OnlineShop.Application.Shop.Payment.ModelDto;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.Payment.Command.VerifyPayment
{
    public class VerifyPaymentCommandHandler : IRequestHandler<VerifyPaymentCommand, Result<VerifyPaymentDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IZarinPalService _zarinPalService;
        private readonly IDailyStatistic _dailyStatistic;
        private readonly IStatisticService _statisticService;

        public VerifyPaymentCommandHandler(ICmsDbContext context, IZarinPalService zarinPalService, IDailyStatistic dailyStatistic, IStatisticService statisticService)
        {
            _context = context;
            _zarinPalService = zarinPalService;
            _dailyStatistic = dailyStatistic;
            _statisticService = statisticService;
        }

        public async Task<Result<VerifyPaymentDto>> Handle(VerifyPaymentCommand request, CancellationToken cancellationToken)
        {
            
            var order = await _context.Orders.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.OrderId, cancellationToken);

            if (order is null)
                return Result<VerifyPaymentDto>.Failed(new ApiMessage(ResponseMessage.OrderNotFound));

            var bankTransaction = await _context.BankTransactions.OrderByDescending(x => x.CreateDate)
                .FirstOrDefaultAsync(x => x.OrderId == request.OrderId, cancellationToken);

            var result = await _zarinPalService.VerifyPayment(request.Authority, Convert.ToInt32(order.FinalAmount));

            #region Failed zarinpal Validation

            if (result.Status != (int)ZarinPalStatus.Success)
            {
                var zarinPalStatus = Enum.GetValues(typeof(ZarinPalStatus));
                bankTransaction.Status = result.Status;

                foreach (int status in zarinPalStatus)
                {
                    if (result.Status == status)
                        return Result<VerifyPaymentDto>.Failed(new ApiMessage(EnumConvertor.GetDisplayName((ZarinPalStatus)status)));
                }
            }

            #endregion

            bankTransaction.RefId = result.RefId;

            order.OrderStatus = OrderStatus.Pending;

            #region Update Stat

            await _statisticService.UpdateOrder(true, cancellationToken).ConfigureAwait(false);

            await _dailyStatistic.UpdateOrder(cancellationToken).ConfigureAwait(false);

            await _dailyStatistic.UpdateRevenue(Convert.ToInt32(order.FinalAmount), cancellationToken).ConfigureAwait(false);

            #endregion

            await _context.SaveAsync(cancellationToken);


            return Result<VerifyPaymentDto>.SuccessFull(new VerifyPaymentDto { RefId = result.RefId });

        }
    }
}