using MediatR;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Blog.Command.DeleteBlog
{
    public class DeleteBlogCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}