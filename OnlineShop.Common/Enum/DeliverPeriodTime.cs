using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common.Enum
{
    public enum DeliverPeriodTime
    {
        [Display(Name = "ساعت 9 تا 12 ")]
        NineToTwelve = 1,
        [Display(Name = "ساعت 12 تا 15 ")]
        TwelveToFifteen = 2,
        [Display(Name = "ساعت 15 تا 18 ")]
        FifteenToSixteen = 3,
        [Display(Name = "ساعت 18 تا 21 ")]
        SixteenToTwentyOne = 4
    }
}