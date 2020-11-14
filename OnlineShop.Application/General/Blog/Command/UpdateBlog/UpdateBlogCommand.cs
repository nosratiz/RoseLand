using System;
using MediatR;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Blog.Command.UpdateBlog
{
    public class UpdateBlogCommand : IRequest<Result>
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string LongDescription { get; set; }

        public string Slug { get; set; }

        public string Tag { get; set; }

        public ContentType ContentType { get; set; }

        public string PublishDate { get; set; }

        public string Image { get; set; }
    }
}