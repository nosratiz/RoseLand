using System.Collections.Generic;
using OnlineShop.Application.General.Blog.Command.UpdateBlog;
using OnlineShop.Application.General.BlogCategory.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Blog.ModelDto
{
    public class UpdateBlogViewModel
    {

        public Result<BlogDto> BlogResult { get; set; }

        public List<BlogCategoryDto> BlogCategoryDto { get; set; }


        public static UpdateBlogViewModel GetUpdateBlogViewModel
            (Result<BlogDto> blogResult, List<BlogCategoryDto> blogCategoryDto)
            => new UpdateBlogViewModel
            {
                BlogCategoryDto = blogCategoryDto,
                BlogResult = blogResult
            };
    }
}