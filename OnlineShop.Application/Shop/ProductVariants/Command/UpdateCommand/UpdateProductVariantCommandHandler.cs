using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.ProductVariants.Command.UpdateCommand
{
    public class UpdateProductVariantCommandHandler : IRequestHandler<UpdateProductVariantCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public UpdateProductVariantCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateProductVariantCommand request, CancellationToken cancellationToken)
        {
            var productVariant =
                await _context.ProductVariants.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (productVariant is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.ProductNotFound)));

            if (request.Price != productVariant.Price)
            {
                await _context.ProductPriceHistories.AddAsync(new ProductPriceHistory
                {
                    Price = request.Price,
                    ProductVariantId = productVariant.Id,
                    CreateDateTime = DateTime.Now
                }, cancellationToken);
            }

            _mapper.Map(request, productVariant);

            _context.ProductVariants.Update(productVariant);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.UpdateSuccessfully)));

        }
    }
}