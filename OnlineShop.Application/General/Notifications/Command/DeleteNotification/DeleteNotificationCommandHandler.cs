using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Notifications.Command.DeleteNotification
{
    public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand, Result>
    {
        private readonly ICmsDbContext _context;

        public DeleteNotificationCommandHandler(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification =
                await _context.Notifications.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

            if (notification is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.NotificationNotFound)));

            notification.IsDeleted = true;

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.UpdateSuccessfully)));
        }
    }
}