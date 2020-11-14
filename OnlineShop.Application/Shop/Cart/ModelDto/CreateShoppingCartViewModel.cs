namespace OnlineShop.Application.Shop.Cart.ModelDto
{
    public class CreateShoppingCartViewModel
    {
        public int ProductVariantId { get; set; }

        public int Count { get; set; }

        public long Price { get; set; }
    }
}