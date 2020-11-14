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
    public class GetMostSailedProductListQuery : IRequest<List<ProductDto>>
    {
        public int Limit { get; set; }
    }


    public class GetMostSailedProductListQueryHandler : IRequestHandler<GetMostSailedProductListQuery, List<ProductDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetMostSailedProductListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetMostSailedProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.Include(x => x.ProductVariants)
            .OrderByDescending(x => x.TotalSailed).Take(request.Limit).ToListAsync(cancellationToken);


            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}