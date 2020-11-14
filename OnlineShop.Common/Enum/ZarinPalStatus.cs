using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common.Enum
{
    public enum ZarinPalStatus
    {
        [Display(Name = "اطلاعات ارسال شده ناقص است.")]
        InCompleteInfo = 1,

        [Display(Name = "و يا مرچنت كد پذيرنده صحيح نيست IP")]
        InvalidIpOrMerchantCode = 2,

        [Display(Name = "با توجه به محدوديت هاي شاپرك امكان پرداخت با رقم درخواست شده ميسر نمي باشد")]
        HugeAmountMoney = 3,

        [Display(Name = "سطح تاييد پذيرنده پايين تر از سطح نقره اي است.")]
        LowerThanSilverLevel = 4,

        [Display(Name = "درخواست مورد نظر يافت نشد.")]
        RequestNotFound = 11,

        [Display(Name = "امكان ويرايش درخواست ميسر نمي باشد.")]
        RequestCanNotEdit = 12,

        [Display(Name = "هيچ نوع عمليات مالي براي اين تراكنش يافت نشد.")]
        FinancialTransactionNotFound = 21,

        [Display(Name = "تراكنش نا موفق ميباشد.")]
        TransactionFailed = 22,

        [Display(Name = "رقم تراكنش با رقم پرداخت شده مطابقت ندارد.")]
        TheAmountIsNotValid = 33,

        [Display(Name = "سقف تقسيم تراكنش از لحاظ تعداد يا رقم عبور نموده است.")]
        TransactionSpilledRoof = 34,

        [Display(Name = "اجازه دسترسي به متد مربوطه وجود ندارد.")]
        MethodNotAllowed = 40,

        [Display(Name = "غيرمعتبر ميباشد. AdditionalData اطلاعات ارسال شده مربوط به")]
        InvalidAdditionalData = 41,

        [Display(Name = "مدت زمان معتبر طول عمر شناسه پرداخت بايد بين 30 دقيه تا 45 روز مي باشد.")]
        InvalidDateStamp = 42,

        [Display(Name = "درخواست مورد نظر آرشيو شده است.")]
        RequestIsArchived = 54,

        [Display(Name = "عمليات با موفقيت انجام گرديده است.")]
        Success = 100,

        [Display(Name = "عمليات پرداخت موفق بوده و قبلا PaymentVerification تراكنش انجام شده است.")]
        PaymentSuccessBefore = 101
    }
}