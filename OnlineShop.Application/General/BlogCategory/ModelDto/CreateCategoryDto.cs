using System.Collections.Generic;
using OnlineShop.Application.General.BlogCategory.Command.CreateCategory;

namespace OnlineShop.Application.General.BlogCategory.ModelDto
{
    public class CreateCategoryDto
    {
        public CreateCategoryCommand CreateCategoryCommand { get; set; }

        public List<BlogCategoryDto> BlogCategory { get; set; }

        public static CreateCategoryDto CreateCategory(List<BlogCategoryDto> blogCategory, CreateCategoryCommand createCategoryCommand = null)
            => new CreateCategoryDto
            {
                BlogCategory = blogCategory,
                CreateCategoryCommand = createCategoryCommand
            };
    }
}