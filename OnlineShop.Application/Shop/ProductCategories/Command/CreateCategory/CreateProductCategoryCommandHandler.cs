using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.ProductCategories.ModelDto;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.ProductCategories.Command.CreateCategory
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, Result<ProductCategoryDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public CreateProductCategoryCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ProductCategoryDto>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = _mapper.Map<ProductCategory>(request);

            await _context.ProductCategories.AddAsync(productCategory, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return Result<ProductCategoryDto>.SuccessFull(_mapper.Map<ProductCategoryDto>(productCategory));
        }
    }
}