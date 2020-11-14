namespace OnlineShop.Application.Shop.Cart.ModelDto
{
    public class BasketViewModel
    {
        public int BasketCount { get; set; }

        public long TotalPrice { get; set; }


        public static BasketViewModel GetBasketViewModel(int basketCount, long totalPrice) => new BasketViewModel
        {
            TotalPrice = totalPrice,
            BasketCount = basketCount
        };
    }
}