using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.DiscountCodes.Command.DeleteDiscountCode
{
    public class DeleteDiscountCodeCommandHandler : IRequestHandler<DeleteDiscountCodeCommand, Result>
    {

        private readonly ICmsDbContext _context;

        public DeleteDiscountCodeCommandHandler(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(DeleteDiscountCodeCommand request, CancellationToken cancellationToken)
        {
            var discountCode = await _context.DiscountCodes.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

            if (discountCode is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.GiftCardNotFound)));


            if (await _context.Orders.AnyAsync(x => !x.IsDeleted && x.DiscountCodeId == request.Id, cancellationToken))
                return Result.Failed(new BadRequestObjectResult(new ApiMessage(ResponseMessage.discountCodeInUse)));

            _context.DiscountCodes.Remove(discountCode);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.DeleteSuccessfully)));
        }
    }
}