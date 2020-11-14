using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.DiscountCodes.Command.UpdateDiscountCode
{
    public class UpdateDiscountCodeCommandHandler : IRequestHandler<UpdateDiscountCodeCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public UpdateDiscountCodeCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateDiscountCodeCommand request, CancellationToken cancellationToken)
        {
            var discountCode = await _context.DiscountCodes.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

            if (discountCode is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.GiftCardNotFound)));

            _mapper.Map(request, discountCode);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.UpdateSuccessfully)));

        }
    }
}