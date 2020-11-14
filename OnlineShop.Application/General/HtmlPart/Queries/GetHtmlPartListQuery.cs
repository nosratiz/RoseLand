using MediatR;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.General.HtmlPart.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.HtmlPart.Queries
{
    public class GetHtmlPartListQuery : PagingOptions, IRequest<Result<PagedList<HtmlPartDto>>>
    {

    }
}