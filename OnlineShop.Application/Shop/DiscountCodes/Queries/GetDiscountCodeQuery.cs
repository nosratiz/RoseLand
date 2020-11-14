using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.DiscountCodes.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.DiscountCodes.Queries
{
    public class GetDiscountCodeQuery : IRequest<Result<DiscountCodeDto>>
    {
        public int Id { get; set; }
    }

    public class GetDiscountCodeQueryHandler : IRequestHandler<GetDiscountCodeQuery, Result<DiscountCodeDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetDiscountCodeQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<DiscountCodeDto>> Handle(GetDiscountCodeQuery request, CancellationToken cancellationToken)
        {
            var discountCode = await _context.DiscountCodes.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

            if (discountCode is null)
                return Result<DiscountCodeDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.GiftCardNotFound)));

            return Result<DiscountCodeDto>.SuccessFull(_mapper.Map<DiscountCodeDto>(discountCode));

        }
    }
}