using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.ProductCategories.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.ProductCategories.Queries
{
    public class GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQuery, Result<ProductCategoryDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetProductCategoryQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ProductCategoryDto>> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var productCategory =
                await _context.ProductCategories.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

            if (productCategory is null)
                return Result<ProductCategoryDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.CategoryNotFound)));

            return Result<ProductCategoryDto>.SuccessFull(_mapper.Map<ProductCategoryDto>(productCategory), request);
        }
    }
}