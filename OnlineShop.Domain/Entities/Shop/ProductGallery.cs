using System;

namespace OnlineShop.Domain.Entities.Shop
{
    public class ProductGallery
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public string Image { get; set; }

        public virtual Product Product { get; set; }
    }
}