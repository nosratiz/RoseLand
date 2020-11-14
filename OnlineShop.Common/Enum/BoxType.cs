using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common.Enum
{
    public enum BoxType
    {
        [Display(Name = "باکس چرمی")]
        LeatherBoxes = 1,
        [Display(Name = "باکس های استوانه ای")]
        CylenderBox = 2
    }
}