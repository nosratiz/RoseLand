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
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.Products.Queries
{
    public class GetProductQuery : IRequest<Result<ProductDto>>
    {
        public int Id { get; set; }
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Result<ProductDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .Include(x => x.ProductCategory)
                .Include(x => x.ProductGalleries)
                .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (products is null)
                return Result<ProductDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.ProductNotFound)));


            return Result<ProductDto>.SuccessFull(_mapper.Map<ProductDto>(products));
        }
    }
}