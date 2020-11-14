using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.ProductCategories.ModelDto;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.ProductCategories.Queries
{
    public class GetProductCategoryListQuery : IRequest<List<ProductCategoryDto>>
    {

    }


    public class GetProductCategoryListQueryHandler : IRequestHandler<GetProductCategoryListQuery, List<ProductCategoryDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetProductCategoryListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductCategoryDto>> Handle(GetProductCategoryListQuery request, CancellationToken cancellationToken)
        {
            var productCategory = await _context.ProductCategories.Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);

            return _mapper.Map<List<ProductCategoryDto>>(productCategory);
        }
    }
}