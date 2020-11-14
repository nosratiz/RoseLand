using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities.Shop
{
    public class Product
    {

        public Product()
        {
            ProductGalleries = new HashSet<ProductGallery>();
            ProductVariants = new HashSet<ProductVariant>();
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string Image { get; set; }
        public string Tag { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsSpecial { get; set; }
        public int TotalView { get; set; }
        public int TotalSailed { get; set; }

        

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductGallery> ProductGalleries { get; }
        public virtual ICollection<ProductVariant> ProductVariants { get; }
        public virtual ICollection<Comment> Comments { get; }
    }
}