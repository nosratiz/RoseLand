namespace OnlineShop.Common.Helper
{
    public class ResponseMessage

    {
        #region Common

        public static string MessageIsRequired = "وارد کردن پیام الزامی می باشد";
        public const string BadRequestQuery = "پارامترهای داده شده معتبر نیست";
        public const string InvalidPagingOption = "پیجینگ وارد شده معتبر نیست";
        public const string InvalidLocalId = "ایدی وارد شده معتبر نیست";
        public const string TokenNotFound = "توکن پیدا نشد";
        public const string InvalidActiveCode = "کد فعالسازی نا معتبر است";
        public const string SendMessageFailed = "ارسال پیامک با مشکل مواجه شده است";
        public const string InvalidPermissionId = "شناسه دسترسی معتبر نیست";
        public const string UserOnlyCanBeInAdminOrUserOrInvited = "کاربر تنها در یکی از لیست های مدیران , اعضا  و دعوت شده ها میتواند باشد";
        public const string MaxSliderShowIsRequired = "وارد کردن تعداد اسلایدر الزامی می باشد";
        public const string MaxSliderShowMustBeNotZero = "تعداد اسلایدر ها باید بزرگتر از یک باشد";
        public const string TransactionNotValid = "تراکنش انجام شده معتبر نمی باشد";
        public const string ParentNotFound = "دسته بندی پدر پیدا نشد";
        public static string UnknownErrorInZarinPal = "خطا در درگاه زرین پال ";
        public static string SlugExist = "اسلاگ از قبل در سامانه موجود می باشد";
        public static string InvalidContentTypeParameter = "the content type that you send was not supported by this api";
        public static string TransactionNotFound = "تراکنش مورد نظر یافت نشد";
        public static string CategoryNotFound = "دسته بندی مورد نظر یافت نشد";
        public static string DeleteSuccessfully = "رکورد با موفیقت حزف شد";
        public static string OrderNotFound = "فاکتور مورد نظر شما پیدا نشد";
        public static string discountCodeInUse = "این کد تخفیف در قاکتور سفارشات موجود می باشد";

        public static string CommentAdded = "کامنت شما با موفقیت ارسال شد پس از تایید بر روی سایت قرار خواهد گرفتس";

        public static string discountCodeNotValid = "کد تخفیف معتبر نمی باشد ";

        public static string DiscountCodeIsExpired = "کد تخفیف منقضی شده است";
        public static string discountCodeNotFound = "کد تخفیف مورد نظر یافت نشد";
        public static string CodeExist = "این کد تخفیف در سیستم موجود می باشد";
        public static string NotificationnotFound = "اطلاع رسانی مورد نظر پیدا نشد";
        public static string DescriptionIsRequired = "وارد کردن توضیحات الزامی می باشد";
        public static string SlugIsRequired = "وارد کردن پیوند یکتا الزامی می باشد";
        public static string PriceIsRequired = "وارد کردن فیمت الزامی می باشد";
        public static string NotAuthorizedRequest = "اجازه دسترسی به این آدرس را ندارید";
        public static string MinLengthName = "نام باید حداقل شامل 3 کارکتر باشد";
        public static string MinLengthFamily = "نام خانوادگی باید حداقل شامل 3 کارکتر باشد";

        #endregion Common

        #region File

        public const string FileNotFound = "فایل مورد نظر پیدا نشد";
        public const string FileExtensionNotSupported = "فرمت فایل ارسال شده مورد تایید نیست";
        public const string MaxSizeReach = "حجم فایل آپلود شده زیاد است";

        #endregion File

        #region User

        public const string InvalidUserCredential = "گذرواژه یا نام کاربری معتبر نمیباشد";
        public const string UserIsDeActive = "حساب کاربری شما  غیر فعال است ";
        public const string UserNotFound = "کاربر مورد نظر پیدا نشد";
        public const string UserAlreadyExist = "کاربری با این مشخصات در سیستم وجود دارد";
        public const string UnAuthorized = "شما اجازه دسترسی به این قسمت را ندارید";
        public const string TokenExpired = "توکن شما منقضی شده است";
        public const string InvalidEmailAddress = "ایمیل نامعتبر است";
        public const string InvalidMobile = "شماره موبایل نامعتبر است";
        public const string InvalidNameOrFamily = "نام یا نام خانوادگی معتبر نیست";
        public const string InvalidUserRole = "نقش کاربر نامعتبر است";
        public const string invalidUsername = "نام کاربری نامعتبر است";
        public const string InvalidUserId = "شناسه کاربر معتبر نمیباشد";
        public const string EmailAddressAlreadyExist = "آدرس ایمیل در سیستم موجود میباشد";
        public const string MobileAlreadyExist = "شماره موبایل در سیستم موجود میباشد";
        public const string UsernameAlreadyExist = "نام کاربری در سیستم موجود میباشد";
        public const string WrongPassword = "گذرواژه صحیح نیست";
        public const string InvalidUserStatus = "وضعیت ورودی کاربر معتبر نمیباشد";
        public const string UserActivityNotFound = "فعالیت مورد نظر پیدا نشد";
        public const string UserCanNotChangeOwnerOfHost = "کاربری که رکورد ایجاد کرده  فقط می تواند به عنوان میزبان پزیرفته شود";
        public static string UserAddSuccessfully = "کاربر با موفیت ساخته شد";
        public static string UserUpdateSuccessfully = "کاربر با موفیقت ویرایش شد";
        public static string InvalidDelete = "اجازه حذف کردن خود از سیستم وجود ندارد";
        public static string CanNotDeleteAdmin = "اجازه حذف کاربر ادمین وجود ندارد";
        public static string UserAddressNotFound = "ادرس مورد نظر پیدا نشد";
        public static string FamilyIsRequired = "وارد کردن نام خانوادگی الزامی می باشد";
        #endregion User

        #region Faq

        public const string FaqNotFound = "محتوا مورد نظر پیدا نشد";
        public const string InvalidFaqId = "شناسه محتوا معتبر نمیباشد";
        public const string InvalidFaqQuestion = "محتوای سوال معتبر نمیباشد";
        public const string InvalidAnswer = "وارد کردم جواب الزامی می باشد";

        #endregion Faq

        #region Blog

        public const string DuplicateBlogTitle = "موضوع بلاگ تکراری است";
        public const string BlogNotFound = "بلاگ مورد نظر پیدا نشد";
        public const string InvalidBlogId = " شناسه بلاگ معتبر نمیباشد";
        public const string BlogTitleIsInvalid = "موضوع بلاگ نامعتبر است";

        #endregion Blog

        #region BlogCategory

        public const string DuplicateName = " نام مورد نظر تکرای است";
        public const string BlogCategoryNotFound = "دسته بندی بلاگ مورد نظر یافت نشد";
        public const string InvalidBlogCategoryId = " شناسه دسته بندی معتبر نمیباشد";
        public const string InvalidBlogCategorySlug = " اسلاگ دسته بندی موجود می باشد ";
        public const string CategoryInUse = "  دسته بندی در حال استفاده است";
        public const string ParentCategoryNotFound = "دسته بندی ای پدر معتبر نمی باشد";
        public const string ParentAndChildrenSame = "دسته بندی و سر دسته نمی تواند یکی باشد";
        public const string AddSuccessfully = "رکورد مورد نظر با موفقیت افزوده شد";
        public const string UpdateSuccessfully = "رکورد مورد نظر با موفقیت ویرایش یافت";
        #endregion BlogCategory

        #region Password

        public const string ForgotPasswordNotAccepted = " درخواست تغییر رمز عبور مورد قبول نیست";
        public const string ForgotPasswordAccepted = "درخواست تغییر رمز عبور مورد قبول است";
        public const string ForgotPassword = "فراموشی رمز عبور";
        public const string ChangePasswordCodeIs = "کد تغییر رمز عبور شما : ";
        public const string PasswordSuccessfullyChanged = "پسورد با موفقیت تغییر کرد";
        public const string InvalidPassword = "شما مجاز به استفاده گذرواژه قبلی به عنوان گذرواژه جدید نیستید";
        public static string PasswordIsRequired = "وارد کردن پسورد الزامی می باشد";
        public static string MaxLengthPassword = "حداقل 6 رمز مورد قبول 6 کارکتر می باشد";

        #endregion Password

        #region ContactUs
        public static string ContentNotFound = "محتوای مورد نظر پیدا نشد";

        #endregion

        #region SlideShow

        public static string SlideShowNotFound = "اسلایدر مورد نظر شما یافت نشد ";

        public static string InvalidDateTime = "تاریخ شروع باید از تاریخ پایان عقب تر باشد";

        public static string ImageIsRequired = "وارد کردن عکس الزامی می باشد";

        public static string NameIsRequired = "وارد کردن نام الزامی می باشد";

        public static string TitleIsRequired = "وارد کردن عنوان الزامی می باشد";

        public static string SortOrderIsRequired = "وارد کردن ترتیب اولویت الزامی است";

        public static string IsVisibleIsRequired = "وارد کردن وضعیت اسلاید شو الزامی می باشد";

        #endregion

        #region HtmlPart

        public const string IsVital = "اجازه حذف محتوا سیستمی وجود ندارد";

        public const string ContentIsRequired = "وارد کردن محتوا الزامی می باشد";

        public const string UniqueNameIsRequired = "وارد کردن نام منحصر به فرد الزامی می باشد";

        public const string UniqueNameAlreadyExist = "نام منحصر به فرد در سیستم وجود دارد ";

        #endregion

        #region Menu

        public const string MenuNotFound = "منو مورد نظر شما پیدا نشد";

        #endregion

        #region order

        public static string UpdateOrderStatusNotAllowed = "امکان تغییر وضعیت سفارش تحویل داده شده وجود ندارد";

        #endregion

        #region product

        public static string ProductNotFound = "محصول مورد نظر شما یافت نشد";
        public static string ProductInUse = "محصول در فاکتور مشتری وجود دارد";
        #endregion

        public static string EmailIsExist = "این ایمیل از قبل وجود دارد";

        public static string InvalidUserNameOrPassword = "نام کاربری یا رمز عبور اشتباه است";

        public static string EmailNotConfirmed = "حساب کاربری خود را از طریق ایمیل ارسالی فعال کنید";

        public static string UserIsNotActive = "کاربر غیر فعال می باشد";

        public static string UserIsLocked = "کاربر به دلیل وارد کردن اشتباه رمز عبور قفل  شده است";

        public static string UserIsDisabled = "کاربر از طرف ادمین غیر فعال شده است";

        public static string RegisterSuccessfully = "اکانت شما با موفقیت ساخته شد یک پیام جهت فعال سازی برای شما ارسال خواهد شد";


        public static string LanguageNotAccepted = "کد زبان ارسال شده مورد پذیرفته نیست";

        public static string PermissionNotFound = "دسترسی مورد نظر یافت نشد";

        public static string RoleNotFound = "نقش مورد نظر شما یافت نشد";

        public static string OrderIdIsRequired = "شماره سفارش ارسال نشده است";

        public const string UserAddressIdIsRequired = "انتخاب آدرس الزامی می باشد";

        public const string DeliverDateIsRequired = "انتخاب زمان تحویل اجباری می باشد";

        public const string PeriodTimeIsRequired = "انتخاب بازه زمانی اجباری می باشد";

        public static string CategoryHasChild = "دسته بندی دارای زیر شاخه میباشد ابتدا زیر شاخه ها را حذف کنید ";

        public static string MessageNotFound = "پیام مورد نظر یافت نشد";


        public static string OutOfRange = "صفحه بندی و تعداد ایتم های در صفحه دارای مقدار مجاز نمی باشد";

        public static string SenderAndReceiverIsSame = "ارسال کننده و دریافت کننده پیام یکی می باشد";

        public static string ParentMessageNotFound = "پیامی که به آن جواب می دهید یافت نشد";



        public static string ArticleNotFound = "مقاله مورد نظر یافت نشد";

        public static string CompanyNotFound = "شرکت مورد نظر پیدا نشد";

        public static string ProductNotfound = "محصول مورد نظر شما پیدا نشد";

        public static string ReceiverNotSet = "دریافت کننده ها تنظیم نشده اند";

        public static string ForbiddenAccessUser = "اجازه دسترسی به پیام وجود ندارد";

        public static string InvalidActivecode = "حساب کاربری شما  به دلیل نامعتبر بودن کد  تایید نشده است";

        public static string ExpiredCode = "کد کاربری شما منقضی شده است";

        public static string AccountVerify = "حساب کاربری شما با موفقیت فعال شد";

        public static string ForgotPasswordSuccessfullySent = "فراموشی رمز عبور برای ایمیل شما با موفقیت ارسال شد";

        public static string ResetPasswordSuccessfully = "رمز عبور شما با موفقیت تغییر یافت";


        public static string PaymentNOtFound = "پرداخت مورد نظر پیدا نشد";



        public static string CommentNotFound = "نظر مورد نظر پیدا نشد";



        public static string DuplicateUniqueName = "نام انحصاری مورد نظر از قبل وجود دارد نام دیگری انتخاب کنید";


        public static string VitalMenu = "امکان حذف منو های ضروری وجود ندارد";

        public static string ParentMenuNotFound = "منو پدر یافت نشد";

        public static string MainPageNotAllowed = "صفحه اصلی از قبل وجود دارد";

        public static string BaseDataNotFound = "دیتا مورد نظر پیدا نشد";

        public static string ProjectNotFound = "پروژه مورد نظر پیدا نشد";

        public static string ServiceNotFound = "سرویس مورد نظر پیدا نشد";

        public static string InvalidCount = "تعداد درخواستی بیش از موجودی در انبار می باشد";

        public static string InvalidProduct = "کالا مورد نظر نامجود می باشد";

        public static string CartNotFound = "ایتم سبد خرید شما پیدا نشد";

        public static string ForbiddenCount = "درخواست تعداد ایتم ها منفی نمی تواند باشد";

        public static string DeliverTypeNotFound = "نحوه ارسال یافت نشد";

        public static string UserCardNotFound = "حساب بانکی مورد نظر یافت نشد";

        public static string GiftCardNotFound = "کد تخفیف مورد نظر یافت نشد";

        public static string BankTransactionNotFound = "تراکنش مورد نظر یافت نشد";

        public static string EmptyCart = "سبد خرید شما خالی می باشد";

        public static string ProductAttributeNotFound = "ویژگی محصول مورد نظر یافت نشد";

        public static string ProductAttributeValueNotFound = "مقدار ویژگی محصول مورد نظر یافت نشد";

        public static string ProductTemplateNotFound = "الگوی محصول مورد نظر یافت نشد";

        public static string ProductCategoryNotSelected = "حداقل یک دسته بندی انتخاب کنید";

        public static string ProductVariantNotFound = "نوع محصول مورد نظر یافت نشد";

        public static string TagNotFound = "تگ مورد نظر شما یافت نشد";

        public static string ProductHasNoPrice = "کالا مورد نظر بدون قیمت می باشد";


        public static string InvalidDeliveryDateTime = "تاریخ تحویل از روز جاری نمی تواند کوچکتر باشد";


        public static string CityNotFound = "شهر مورد نظر شما پیدا نشد";

        public static string EmptyCode = "وارد کردن کد تخفیف الزامی میباشد";

        public static string OutDateGiftCard = "کد تخفیف مورد نظر منقضی شده است";

        public static string EmptyGiftCardCount = "تعداد اعتبار کد تخفیف مورد نظر تمام شده است";

        public static string CountIsRequired = "وارد کردن تعداد الزامی می باشد";

        public static string AmountIsRequired = "وارد کردن مقدار الزامی می باشد";



        public static string GiftCardUseBefore = "کد تخفیف قبلا مورد استفاده قرار گرفته است";

        public static string AccountNotConfirm = " برای ورود به سیستم تایدیه حساب کاربری لازم می باشد ";

        public static string EmptyToken = "توکن ارسال نشد";


        public static string ExpiredToken = "توکن منقضی شده است";

        public static string TemplateIsVital = "اجازه حذف ویژگی پیش فرض سیستم وجود ندارد";

        public static string InvalidPercentage = "درصد تخفیف نمی تواند بیشتر از 100 یا کمتر از 0 باشد";

        public static string OrderDiscount = "سفارش دارای کد تخفیف  نمی باشد";

        public static string InvalidDiscount = "قیمت تخفیف نباید از قیمت خودمحصول بیشتر باشد";

        public static string RateIsNull = "نمره ای برای محصول وارد نشده است";

        public static string ReplyNotAllowed = "امکان پاسخ دادن به پیام تماس با ما وجود ندارد";

        public static string EmptyEmail = "ایمیل نباید خالی باشد";

        public static string PhoneNumberEmpty = "تلفن نباید خالی باشد";

        public static string PhonePanelIssue = "مشکل در ارسال پیام";

        public static string PhoneNotConfirmed = "شماره تلفن همراه تایید نشده است";


        public static string StatTypeNotSupported = "آمار مورد نظر به درستی انتخاب نشده است";

        public static string CommentTypeNotSupported = "نوع کامنت مشخص نشده است";

        public static string BreadCrumbTypeNotSupported = "bread crumb type not supported";

        public static string LowerThanStartDiscountPrice = "مبلغ خرید شما به حداقل قیمت مورد نیاز برای استفاده از تخفیف نرسیده است";

        public static string OrderItemNotExistInBrand = "افلام خریداری شده شامل برند های تخفیف داده شده نمی باشد";

        public static string OrderItemNotFoundInCategory = "افلام خریداری شده شامل دسته بندی های دارای تخفیف نمی باشد";

        public static string PasswordRecentlyUsed = "این پسورد اخیرا استفاده شده پسورد دیگری انتخاب نمایید";

        public static string ChangePaymentTypeNotAllowed = "تغییر شیوه پرداخت پی از انجام تراکنش وجود ندارد";

        public static string NotificationNotFound = "نوتیفیکیشن مورد نظر یافت نشد";
    }
}