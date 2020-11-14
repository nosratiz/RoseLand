using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Products.ModelDto;

namespace OnlineShop.Application.Shop.Products.Queries
{
    public class GetMostVisitedProductListQuery : IRequest<List<ProductDto>>
    {
        public int Limit { get; set; }
    }

    public class GetMostVisitedProductListQueryHandler : IRequestHandler<GetMostVisitedProductListQuery, List<ProductDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetMostVisitedProductListQueryHandler(IMapper mapper, ICmsDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<ProductDto>> Handle(GetMostVisitedProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.Include(x => x.ProductVariants)
            .OrderByDescending(x => x.TotalView).Take(request.Limit).ToListAsync(cancellationToken);


            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}