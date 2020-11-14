using MediatR;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.General.Notifications.Command.ReadCommand
{
    public class ReadNotificationCommand : IRequest<Result>
    {
        public long Id { get; set; }
    }
}