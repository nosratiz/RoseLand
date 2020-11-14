using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.ProductVariants.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.ProductVariants.Queries
{
    public class GetProductVariantQuery : IRequest<Result<ProductVariantDto>>
    {
        public int Id { get; set; }
    }

    public class GetProductVariantQueryHandler : IRequestHandler<GetProductVariantQuery, Result<ProductVariantDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetProductVariantQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ProductVariantDto>> Handle(GetProductVariantQuery request, CancellationToken cancellationToken)
        {
            var productVariant =
                await _context.ProductVariants.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (productVariant is null)
                return Result<ProductVariantDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.ProductNotFound)));

            return Result<ProductVariantDto>.SuccessFull(_mapper.Map<ProductVariantDto>(productVariant));
        }

    }
}