using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Products.ModelDto;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.Comments.Queries
{
    public class GetRelatedProductQuery : IRequest<List<ProductDto>>
    {
        public int CategoryId { get; set; }

        public int ProductId { get; set; }
    }

    public class GetRelatedProductQueryHandler : IRequestHandler<GetRelatedProductQuery, List<ProductDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetRelatedProductQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetRelatedProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Include(x => x.ProductVariants)
                .Where(x => x.ProductCategoryId == request.CategoryId && x.Id != request.ProductId && x.ProductVariants.Any())
                .ToListAsync(cancellationToken);


            return _mapper.Map<List<ProductDto>>(product);
        }
    }
}