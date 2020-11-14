using MediatR;
using OnlineShop.Application.General.ContactUs.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.ContactUs.Command
{
    public class CreateContactUsCommand : IRequest<Result<ContactUsDto>>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }
    }
}