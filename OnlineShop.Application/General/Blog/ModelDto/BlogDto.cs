using System;
using System.Collections.Generic;
using OnlineShop.Application.General.BlogCategory.ModelDto;
using OnlineShop.Application.Users.ModelDto;
using OnlineShop.Common.Enum;

namespace OnlineShop.Application.General.Blog.ModelDto
{
    public class BlogDto
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string LongDescription { get; set; }

        public string Slug { get; set; }

        public List<string> Tag { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? PublishDate { get; set; }

        public int TotalUniqueView { get; set; }

        public int TotalView { get; set; }

        public string Image { get; set; }

        public virtual UserDto User { get; set; }

        public virtual BlogCategoryDto BlogCategory { get; set; }
    }
}