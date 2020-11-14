using System.Collections.Generic;

namespace OnlineShop.Domain.Entities.Shop
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            Children = new HashSet<ProductCategory>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }

        public string Slug { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int ProductCount { get; set; }


        public virtual ProductCategory Parent { get; set; }
        public virtual ICollection<ProductCategory> Children { get; }
        public virtual ICollection<Product> Products { get; }
    }
}