using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.ProductVariants.ModelDto;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.ProductVariants.Command.CreateCommand
{
    public class CreateProductVariantCommandHandler : IRequestHandler<CreateProductVariantCommand, Result<ProductVariantDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public CreateProductVariantCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ProductVariantDto>> Handle(CreateProductVariantCommand request, CancellationToken cancellationToken)
        {
            var productVariant = _mapper.Map<ProductVariant>(request);

            await _context.ProductVariants.AddAsync(productVariant, cancellationToken);

            await _context.ProductPriceHistories.AddAsync(new ProductPriceHistory
            {
                ProductVariant = productVariant,
                CreateDateTime = DateTime.Now,
                Price = request.Price,
            }, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return Result<ProductVariantDto>.SuccessFull(_mapper.Map<ProductVariantDto>(productVariant));
        }
    }
}