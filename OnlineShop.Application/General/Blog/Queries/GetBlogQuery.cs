using MediatR;
using OnlineShop.Application.General.Blog.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Blog.Queries
{
    public class GetBlogQuery : IRequest<Result<BlogDto>>
    {
        public int Id { get; set; }
    }
}