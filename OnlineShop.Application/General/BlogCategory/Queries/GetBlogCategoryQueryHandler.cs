using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.BlogCategory.Command.UpdateCategory;
using OnlineShop.Application.General.BlogCategory.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.BlogCategory.Queries
{
    public class GetBlogCategoryQueryHandler : IRequestHandler<GetBlogCategoryQuery, Result<BlogCategoryDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetBlogCategoryQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<BlogCategoryDto>> Handle(GetBlogCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.BlogCategories.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

            if (category is null)
                return Result<BlogCategoryDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.BlogCategoryNotFound)));

            return Result<BlogCategoryDto>.SuccessFull(_mapper.Map<BlogCategoryDto>(category));
        }
    }

    public class GetUpdateBlogCategoryQuery : IRequest<Result<UpdateCategoryCommand>>
    {
        public int Id { get; set; }
    }

    public class GetUpdateBlogCategoryHandler : IRequestHandler<GetUpdateBlogCategoryQuery, Result<UpdateCategoryCommand>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetUpdateBlogCategoryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<UpdateCategoryCommand>> Handle(GetUpdateBlogCategoryQuery request, CancellationToken cancellationToken)
        {

            var category = await _context.BlogCategories.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

            if (category is null)
                return Result<UpdateCategoryCommand>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.BlogCategoryNotFound)));

            return Result<UpdateCategoryCommand>.SuccessFull(_mapper.Map<UpdateCategoryCommand>(category));

        }
    }
}