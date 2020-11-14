using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.BlogCategory.Command.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.BlogCategories.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

            if (category is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.BlogCategoryNotFound)));

            _mapper.Map(request, category);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.UpdateSuccessfully)));

        }
    }
}