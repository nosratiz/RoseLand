using OnlineShop.Common.Enum;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.Cart.ModelDto
{
    public class BasketShopViewModel
    {
        public int Count { get; set; }

        public int ProductVariantId { get; set; }

        public int ProductId { get; set; }

        public string Slug { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public long Price { get; set; }


        public BoxType BoxType { get; set; }



        public static BasketShopViewModel GetBasketShopViewModel(CreateShoppingCartViewModel createShoppingCart,
            ProductVariant productVariant) => new BasketShopViewModel
            {
                ProductVariantId = createShoppingCart.ProductVariantId,
                Count = createShoppingCart.Count,
                Image = productVariant.Product.Image,
                Slug = productVariant.Product.Slug,
                Name = productVariant.Product.Name,
                Price = productVariant.DiscountPrice ?? productVariant.Price,
                ProductId = productVariant.ProductId,
                BoxType = productVariant.BoxType
            };
    }
}