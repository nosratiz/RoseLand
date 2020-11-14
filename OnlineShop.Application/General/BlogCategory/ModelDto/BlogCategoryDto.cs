using System.Collections.Generic;

namespace OnlineShop.Application.General.BlogCategory.ModelDto
{
    public class BlogCategoryDto
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string ParentName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Logo { get; set; }

        public string Slug { get; set; }

        public int BlogCount { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<BlogCategoryDto> Children { get; set; }
    }
}