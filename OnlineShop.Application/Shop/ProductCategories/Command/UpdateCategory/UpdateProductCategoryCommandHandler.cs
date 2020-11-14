using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.ProductCategories.Command.UpdateCategory
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public UpdateProductCategoryCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory =
                await _context.ProductCategories.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

            if (productCategory is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.CategoryNotFound)));

            _mapper.Map(request, productCategory);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.UpdateSuccessfully)));
        }
    }
}