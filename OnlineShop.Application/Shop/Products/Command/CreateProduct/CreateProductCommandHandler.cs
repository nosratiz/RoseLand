using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Statistic;
using OnlineShop.Application.Shop.Products.ModelDto;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<ProductDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStatisticService _statisticService;

        public CreateProductCommandHandler(ICmsDbContext context, IMapper mapper, IStatisticService statisticService)
        {
            _context = context;
            _mapper = mapper;
            _statisticService = statisticService;
        }

        public async Task<Result<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            await _context.Products.AddAsync(product, cancellationToken);

            foreach (var image in request.Galleries)
            {
                await _context.ProductGalleries.AddAsync(new ProductGallery
                {
                    Image = image,
                    Product = product
                }, cancellationToken);
            }

            var productCategory =
                await _context.ProductCategories.SingleOrDefaultAsync(x => x.Id == request.ProductCategoryId, cancellationToken);

            productCategory.ProductCount += 1;

            await _statisticService.UpdateProductCount(true, cancellationToken).ConfigureAwait(false);

            await _context.SaveAsync(cancellationToken);

            return Result<ProductDto>.SuccessFull(_mapper.Map<ProductDto>(product));
        }
    }
}