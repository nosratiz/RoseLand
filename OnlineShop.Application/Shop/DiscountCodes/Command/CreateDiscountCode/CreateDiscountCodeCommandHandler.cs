using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.DiscountCodes.ModelDto;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.DiscountCodes.Command.CreateDiscountCode
{
    public class CreateDiscountCodeCommandHandler : IRequestHandler<CreateDiscountCodeCommand, Result<DiscountCodeDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public CreateDiscountCodeCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<DiscountCodeDto>> Handle(CreateDiscountCodeCommand request, CancellationToken cancellationToken)
        {
            var discountCode = _mapper.Map<DiscountCode>(request);

            await _context.DiscountCodes.AddAsync(discountCode, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return Result<DiscountCodeDto>.SuccessFull(_mapper.Map<DiscountCodeDto>(discountCode));
        }
    }
}