using System;

namespace OnlineShop.Common.Helper
{
    public static class DiscountPercentageCalculator
    {
        public static int Calculate(long price, long? discountPrice)
        {
            if (discountPrice is null || discountPrice.Value == 0)
                return 0;

            var amount = (Convert.ToDouble(price - discountPrice.Value) / price) * 100;

            return Convert.ToInt32(amount);

        }
    }
}