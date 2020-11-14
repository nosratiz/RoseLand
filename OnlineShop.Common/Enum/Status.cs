using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common.Enum
{
    public enum Status
    {
        [Display(Name = "فعال")]
        Active = 1,
        [Display(Name = "غیرفعال")]
        Deactivate = 2,
        [Display(Name = "بلاک")]
        Suspend = 3,
        Delete = 4
    }
}