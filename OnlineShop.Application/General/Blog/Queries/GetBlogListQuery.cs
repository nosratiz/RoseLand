using MediatR;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.General.Blog.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Blog.Queries
{
    public class GetBlogListQuery : PagingOptions, IRequest<Result<PagedList<BlogDto>>>
    {
        public string Category { get; set; }
    }
}