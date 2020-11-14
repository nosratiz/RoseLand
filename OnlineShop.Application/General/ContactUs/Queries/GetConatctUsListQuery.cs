using MediatR;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.General.ContactUs.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.ContactUs.Queries
{
    public class GetContactUsListQuery : PagingOptions, IRequest<Result<PagedList<ContactUsDto>>>
    {

    }
}