using System.Collections.Generic;
using OnlineShop.Application.General.BlogCategory.Command.UpdateCategory;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.BlogCategory.ModelDto
{
    public class UpdateBlogCategoryViewModel
    {
        public UpdateCategoryCommand UpdateCategoryCommand { get; set; }

        public Result<BlogCategoryDto> BlogCategoryResult { get; set; }

        public List<BlogCategoryDto> BlogCategoryList { get; set; }

        public static UpdateBlogCategoryViewModel UpdateBlogCategoryView(List<BlogCategoryDto> blogCategoryList,
            Result<BlogCategoryDto> blogCategoryResult, UpdateCategoryCommand updateCategoryCommand = null)
            => new UpdateBlogCategoryViewModel
            {
                BlogCategoryList = blogCategoryList,
                UpdateCategoryCommand = updateCategoryCommand,
                BlogCategoryResult = blogCategoryResult
            };

    }
}