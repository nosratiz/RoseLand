using MediatR;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.General.Notifications.Command.DeleteNotification
{
    public class DeleteNotificationCommand : IRequest<Result>
    {
        public long Id { get; set; }
    }
}