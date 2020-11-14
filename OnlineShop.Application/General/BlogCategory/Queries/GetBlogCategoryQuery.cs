using MediatR;
using OnlineShop.Application.General.BlogCategory.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.BlogCategory.Queries
{
    public class GetBlogCategoryQuery : IRequest<Result<BlogCategoryDto>>
    {
        public int Id { get; set; }
    }
}