using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (product is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.ProductNotFound)));

         

            _mapper.Map(request, product);

            #region Handle Gallery

            var productGallery = await _context.ProductGalleries.Where(x => x.ProductId == request.Id).ToListAsync(cancellationToken);

            _context.ProductGalleries.RemoveRange(productGallery);

            foreach (var image in request.Galleries)
            {
                await _context.ProductGalleries.AddAsync(new ProductGallery
                {
                    Image = image,
                    ProductId = request.Id
                }, cancellationToken);
            }

            await _context.SaveAsync(cancellationToken);

            #endregion

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.UpdateSuccessfully)));

        }
    }
}