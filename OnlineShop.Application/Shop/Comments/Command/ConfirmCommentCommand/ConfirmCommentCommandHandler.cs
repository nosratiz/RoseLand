using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.Comments.Command.ConfirmCommentCommand
{
    public class ConfirmCommentCommandHandler : IRequestHandler<ConfirmCommentCommand, Result>
    {
        private readonly ICmsDbContext _context;

        public ConfirmCommentCommandHandler(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(ConfirmCommentCommand request, CancellationToken cancellationToken)
        {
            var comment =
                await _context.Comments.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id,
                    cancellationToken);

            if (comment is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.CommentNotFound)));

            comment.IsConfirm = !comment.IsConfirm;

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new ObjectResult(new ApiMessage(ResponseMessage.UpdateSuccessfully)));
        }
    }
}