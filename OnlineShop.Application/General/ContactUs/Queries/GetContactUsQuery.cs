using MediatR;
using OnlineShop.Application.General.ContactUs.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.ContactUs.Queries
{
    public class GetContactUsQuery : IRequest<Result<ContactUsDto>>
    {
        public long Id { get; set; }
    }
}