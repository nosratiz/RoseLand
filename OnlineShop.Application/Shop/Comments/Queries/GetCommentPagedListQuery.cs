using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Comments.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.Comments.Queries
{
    public class GetCommentPagedListQuery : PagingOptions, IRequest<Result<PagedList<CommentDto>>>
    {

    }

    public class GetCommentPagedListQueryHandler : PagingService<Comment>, IRequestHandler<GetCommentPagedListQuery, Result<PagedList<CommentDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetCommentPagedListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<CommentDto>>> Handle(GetCommentPagedListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Comment> commentList = _context.Comments.Where(x => !x.IsDeleted)
                .Include(x => x.User).Include(x=>x.Product);

            if (!string.IsNullOrWhiteSpace(request.Search))
                commentList = commentList
                    .Where(x => x.Description.Contains(request.Search) || x.User.Name.Contains(request.Search) ||
                                x.User.Family.Contains(request.Search) || x.Product.Name.Contains(request.Search)).Include(x => x.Product);


            var commentPagedList = await GetPagedAsync(request.Page, request.Limit, commentList);

            return Result<PagedList<CommentDto>>.SuccessFull(commentPagedList.MapTo<CommentDto>(_mapper), request);
        }
    }
}