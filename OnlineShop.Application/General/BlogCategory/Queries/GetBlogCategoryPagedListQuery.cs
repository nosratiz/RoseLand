using MediatR;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.General.BlogCategory.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.BlogCategory.Queries
{
    public class GetBlogCategoryPagedListQuery : PagingOptions, IRequest<Result<PagedList<BlogCategoryDto>>>
    {

    }
}