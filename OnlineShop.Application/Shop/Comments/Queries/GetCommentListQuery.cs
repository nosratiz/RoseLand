using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Comments.ModelDto;

namespace OnlineShop.Application.Shop.Comments.Queries
{
    public class GetCommentListQuery : IRequest<List<CommentDto>>
    {
        public long UserId { get; set; }
    }

    public class GetCommentListQueryHandler : IRequestHandler<GetCommentListQuery, List<CommentDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetCommentListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {
            var comments = await _context.Comments.Include(x => x.Product)
            .Where(x => !x.IsDeleted && x.UserId == request.UserId)
                .ToListAsync(cancellationToken);


            return _mapper.Map<List<CommentDto>>(comments);
        }
    }
}