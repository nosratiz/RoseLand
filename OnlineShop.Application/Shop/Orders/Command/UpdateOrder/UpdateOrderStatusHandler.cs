using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Statistic;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.Orders.Command.UpdateOrder
{
    public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusCommand, Result>
    {
        private readonly ICmsDbContext _context;
    

        public UpdateOrderStatusHandler(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

            if (order is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.OrderNotFound)));

            if (order.OrderStatus == OrderStatus.Delivered)
                return Result.Failed(new BadRequestObjectResult(new ApiMessage(ResponseMessage.UpdateOrderStatusNotAllowed)));


            order.OrderStatus = request.OrderStatus;

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.UpdateSuccessfully)));
        }
    }
}