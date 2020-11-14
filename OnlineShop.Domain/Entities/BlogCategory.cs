using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public class BlogCategory
    {
        public BlogCategory()
        {
            Children = new HashSet<BlogCategory>();

            Blogs = new List<Blog>();
        }
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Logo { get; set; }

        public string Slug { get; set; }

        public bool IsActive { get; set; }

        public int BlogCount { get; set; }

        public bool IsDeleted { get; set; }

        public virtual BlogCategory Parent { get; set; }
        public virtual ICollection<BlogCategory> Children { get; }
        public virtual ICollection<Blog> Blogs { get; }
    }
}