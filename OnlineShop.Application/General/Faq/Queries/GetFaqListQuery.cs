using MediatR;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.General.Faq.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Faq.Queries
{
    public class GetFaqListQuery : PagingOptions, IRequest<Result<PagedList<FaqDto>>>
    {

    }
}