using System;
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
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.Comments.Command.ReplyCommentCommand
{
    public class ReplyCommentCommandHandler : IRequestHandler<ReplyCommentCommand, Result<CommentDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public ReplyCommentCommandHandler(ICmsDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Result<CommentDto>> Handle(ReplyCommentCommand request, CancellationToken cancellationToken)
        {
            var comment =
                await _context.Comments.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id,
                    cancellationToken);

            if (comment is null)
                return Result<CommentDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.CommentNotFound)));

            var replyComment = new Comment
            {
                CreateDate = DateTime.Now,
                Description = request.Description,
                ParentId = request.Id,
                IsConfirm = true,
                ProductId = comment.ProductId,
                UserId = int.Parse(_currentUserService.UserId)
            };

            await _context.Comments.AddAsync(replyComment, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return Result<CommentDto>.SuccessFull(_mapper.Map<CommentDto>(replyComment));
        }
    }
}