using System;
using System.Collections.Generic;
using MediatR;
using OnlineShop.Application.General.Blog.ModelDto;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Blog.Command.CreateBlog
{
    public class CreateBlogCommand : IRequest<Result<BlogDto>>
    {
        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string LongDescription { get; set; }

        public string Slug { get; set; }

        public List<string> Tag { get; set; }

        public ContentType ContentType { get; set; }

        public string PublishDate { get; set; }

        public string Image { get; set; }
    }
}