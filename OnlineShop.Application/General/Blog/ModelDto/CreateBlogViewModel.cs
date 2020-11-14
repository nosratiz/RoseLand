using System.Collections.Generic;
using OnlineShop.Application.General.Blog.Command.CreateBlog;
using OnlineShop.Application.General.BlogCategory.ModelDto;

namespace OnlineShop.Application.General.Blog.ModelDto
{
    public class CreateBlogViewModel
    {
        public List<BlogCategoryDto> BlogCategory { get; set; }


        public static CreateBlogViewModel CreateBlogView(List<BlogCategoryDto> blogCategory)
      => new CreateBlogViewModel
      {
          BlogCategory = blogCategory
      };
    }
}