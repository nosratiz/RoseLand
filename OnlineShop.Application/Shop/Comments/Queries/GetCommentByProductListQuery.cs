using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Comments.ModelDto;
using OnlineShop.Application.Shop.Products.ModelDto;


namespace OnlineShop.Application.Shop.Comments.Queries
{
    public class GetCommentByProductListQuery : IRequest<List<CommentDto>>
    {
        public int ProductId { get; set; }
    }


    public class GetCommentByProductListQueryHandler : IRequestHandler<GetCommentByProductListQuery, List<CommentDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetCommentByProductListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> Handle(GetCommentByProductListQuery request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments
                .Include(x => x.User)
                .Where(x => !x.IsDeleted && x.IsConfirm && x.ProductId == request.ProductId)
                .OrderByDescending(x => x.CreateDate)
                .Take(10).ToListAsync(cancellationToken);

            return _mapper.Map<List<CommentDto>>(comment);

        }
    }
}