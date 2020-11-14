using MediatR;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.ContactUs.Command
{
    public class DeleteContactUsCommand : IRequest<Result>
    {
        public long Id { get; set; }
    }
}