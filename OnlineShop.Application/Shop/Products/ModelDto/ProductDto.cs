using System;
using System.Collections.Generic;
using OnlineShop.Application.Shop.ProductCategories.ModelDto;
using OnlineShop.Application.Shop.ProductVariants.ModelDto;

namespace OnlineShop.Application.Shop.Products.ModelDto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string Image { get; set; }
        public string Tag { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsSpecial { get; set; }
        public long Price { get; set; }
        public long? DiscountPrice { get; set; }
        public bool HasDiscount { get; set; }
        public long ProductVariantId { get; set; }


        public virtual ProductCategoryDto ProductCategory { get; set; }
        public virtual List<ProductGalleryDto> ProductGalleries { get; set; }

        public virtual List<ProductVariantDto> ProductVariants { get; set; }
    }
}