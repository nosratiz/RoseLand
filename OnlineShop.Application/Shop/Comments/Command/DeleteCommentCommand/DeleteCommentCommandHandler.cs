using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.Comments.Command.DeleteCommentCommand
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Result>
    {
        private readonly ICmsDbContext _context;

        public DeleteCommentCommandHandler(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment =
                await _context.Comments.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id,
                    cancellationToken);

            if (comment is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.CommentNotFound)));

            comment.IsDeleted = true;

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.DeleteSuccessfully)));
        }
    }
}