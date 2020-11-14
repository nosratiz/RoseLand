using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Products.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.Products.Queries
{
    public class GetProductBySlugQuery : IRequest<Result<ProductDto>>
    {
        public string Slug { get; set; }
    }

    public class GetProductBySlugQueryHandler : IRequestHandler<GetProductBySlugQuery, Result<ProductDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetProductBySlugQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ProductDto>> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Include(x => x.ProductVariants)
                .Include(x => x.ProductCategory)
                .Include(x => x.ProductGalleries)
                .SingleOrDefaultAsync(x => x.Slug == request.Slug, cancellationToken);


            if (product is null)
                return Result<ProductDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.ProductNotFound)));


            return Result<ProductDto>.SuccessFull(_mapper.Map<ProductDto>(product));
        }

    }
}