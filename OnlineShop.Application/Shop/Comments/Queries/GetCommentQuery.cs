using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Comments.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.Comments.Queries
{
    public class GetCommentQuery : IRequest<Result<CommentDto>>
    {
        public int Id { get; set; }
    }

    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, Result<CommentDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetCommentQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<CommentDto>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var comment =
                await _context.Comments.Include(x => x.User).Include(x => x.Product)
                    .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (comment is null)
                return Result<CommentDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.CommentNotFound)));


            return Result<CommentDto>.SuccessFull(_mapper.Map<CommentDto>(comment));
        }
    }
}