using MediatR;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.General.SlideShow.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.SlideShow.Queries
{
    public class GetSlideShowPagedListQuery : PagingOptions, IRequest<Result<PagedList<SlideShowDto>>>
    {

    }
}