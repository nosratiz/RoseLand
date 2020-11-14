using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Blog.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Blog.Queries
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, Result<BlogDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<BlogDto>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blog = await _context.Blogs.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (blog is null)
                return Result<BlogDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.BlogNotFound)));

            return Result<BlogDto>.SuccessFull(_mapper.Map<BlogDto>(blog));
        }
    }
}