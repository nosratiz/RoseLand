using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Shop;
using OnlineShop.Domain.Entities.statistic;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Application.System
{
    public class SeedData
    {
        private readonly ICmsDbContext _context;

        public SeedData(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task SeedAllAsync(CancellationToken cancellation)
        {
            #region SeedData


            if (!await _context.Roles.AnyAsync(cancellation))
            {
                await _context.Roles.AddAsync(new Role
                {
                    Name = "Admin"
                }, cancellation);
                await _context.Roles.AddAsync(new Role
                {
                    Name = "User"
                }, cancellation);

                await _context.SaveAsync(cancellation);

            }

            if (!await _context.Users.AnyAsync(cancellation))
            {
                await _context.Users.AddAsync(new User
                {

                    Name = "نیما",
                    Family = "نصرتی",
                    Email = "nimanosrati93@gmail.com",
                    Password = PasswordManagement.HashPass("nima1234!"),
                    ActivationCode = Guid.NewGuid(),
                    PhoneNumber = "09107602786",
                    IsEmailConfirmed = true,
                    IsPhoneConfirmed = true,
                    Status = Status.Active,
                    RoleId = 1,
                    RegisterDate = DateTime.Now,
                    ExpiredVerification = DateTime.Now.AddDays(2)
                }, cancellation);

                await _context.SaveAsync(cancellation);
            }

            if (!await _context.ContactUses.AnyAsync(cancellation))
            {
                await _context.ContactUses.AddAsync(new ContactUs
                {
                    Name = "عادل",
                    Email = "adelmehraban@gmail.com",
                    Message = "سلام",
                    CreateDate = DateTime.Now
                }, cancellation);
                await _context.SaveAsync(cancellation);
            }

            if (!await _context.BlogCategories.AnyAsync(cancellation))
            {
                await _context.BlogCategories.AddAsync(new BlogCategory
                {
                    Name = "اقتصادی",
                    Description = "",
                    IsActive = true,
                    Slug = "economy",
                    Logo = "/Uploads/images/user-info.jpg"
                });
                await _context.SaveAsync(cancellation);
            }

            if (!await _context.Blogs.AnyAsync(cancellation))
            {
                await _context.Blogs.AddAsync(new Blog
                {
                    CreateDate = DateTime.Now,
                    ContentType = ContentType.Article,
                    CategoryId = 1,
                    Title = "فرار مغزها",
                    Image = "/Uploads/images/user-info.jpg",
                    PublishDate = DateTime.Now,
                    Description = "فراری های از دست بهروز نجات یافتند",
                    LongDescription = "فراری های از دست بهروز نجات یافتند",
                    UserId = 1,
                    Slug = "escape",
                    Tag = "[]"
                }, cancellation);
                await _context.SaveAsync(cancellation);
            }

            if (!await _context.Menus.AnyAsync(cancellation))
            {
                _context.Menus.Add(new Menu { IsDeleted = false, IsVital = true, TotalView = 0, TotalUniqueView = 0, IsPublish = true, Title = "صفحه اصلی", SortOrder = 1, CreationDate = DateTime.Now, UniqueName = "Home", MenuType = MenuType.System, Controller = "Home", Action = "Index" });
                _context.Menus.Add(new Menu { IsDeleted = false, IsVital = true, TotalView = 0, TotalUniqueView = 0, IsPublish = true, Title = "محصولات", SortOrder = 2, CreationDate = DateTime.Now, UniqueName = "Product", MenuType = MenuType.System, Controller = "Product", Action = "ProductList" });
                _context.Menus.Add(new Menu { IsDeleted = false, IsVital = true, TotalView = 0, TotalUniqueView = 0, IsPublish = true, Title = "وبلاگ", SortOrder = 3, CreationDate = DateTime.Now, UniqueName = "Blog", MenuType = MenuType.System, Controller = "Blog", Action = "BlogList" });
                _context.Menus.Add(new Menu { IsDeleted = false, IsVital = true, TotalView = 0, TotalUniqueView = 0, IsPublish = true, Title = "تماس با ما", SortOrder = 5, CreationDate = DateTime.Now, UniqueName = "ContactUs", MenuType = MenuType.Page, Controller = "Home", Action = "ContactUs" });
                _context.Menus.Add(new Menu { IsDeleted = false, IsVital = true, TotalView = 0, TotalUniqueView = 0, IsPublish = true, Title = "درباره ما", SortOrder = 6, CreationDate = DateTime.Now, UniqueName = "AboutUs", MenuType = MenuType.Page, Controller = "Home", Action = "AboutUs" });
                _context.Menus.Add(new Menu { IsDeleted = false, IsVital = true, TotalView = 0, TotalUniqueView = 0, IsPublish = true, Title = "سوالات متداول", SortOrder = 7, CreationDate = DateTime.Now, UniqueName = "Faq", MenuType = MenuType.System, Controller = "Home", Action = "Faq" });

                await _context.SaveAsync(cancellation);
            }

            if (!await _context.ProductCategories.AnyAsync(cancellation))
            {
                await _context.ProductCategories.AddAsync(new ProductCategory
                {
                    Name = "اقتصادی",
                    Description = "",
                    Slug = "economy",
                    Image = "/Uploads/images/user-info.jpg",
                    ProductCount = 0
                }, cancellation);

                await _context.SaveAsync(cancellation);
            }

            if (!await _context.DiscountCodes.AnyAsync(cancellation))
            {
                await _context.DiscountCodes.AddAsync(new DiscountCode
                {
                    CreateDate = DateTime.Now,
                    Code = "rl-241",
                    Count = 10,
                    DiscountType = DiscountType.Amount,
                    EndDateTime = DateTime.Now.AddDays(100),
                    StartDate = DateTime.Now,
                    IsActive = true,
                    Price = 5000,
                    UsageCount = 0
                }, cancellation);

                await _context.SaveAsync(cancellation);
            }

            if (!await _context.SlideShows.AnyAsync(cancellation))
            {
                await _context.SlideShows.AddAsync(new SlideShow
                {
                    Title = "رزلند",
                    IsVisible = true,
                    Name = "رزلند",
                    Image = "/Uploads/images/user-info.jpg",
                    SortOrder = 1
                }, cancellation);

                await _context.SaveAsync(cancellation);
            }

            if (!await _context.Products.AnyAsync(cancellation))
            {
                await _context.Products.AddAsync(new Product
                {
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Name = "باکس های خوابیده رزلند",
                    Description = "گل های زیبا",
                    Image = "/Uploads/images/user-info.jpg",
                    ProductCategoryId = 1,
                    Slug = "roseland"

                }, cancellation);
                await _context.SaveAsync(cancellation);
            }

            if (!await _context.ProductVariants.AnyAsync(cancellation))
            {
                await _context.ProductVariants.AddAsync(new ProductVariant
                {
                    BoxType = BoxType.CylenderBox,
                    Count = 9,
                    Price = 145000,
                    DiscountPrice = 130000,
                    ProductId = 1
                }, cancellation);

                await _context.SaveAsync(cancellation);
            }

            if (!await _context.UserAddresses.AnyAsync(cancellation))
            {
                await _context.UserAddresses.AddAsync(new Domain.Entities.Shop.UserAddress
                {
                    Address = "خیابان پیروزی خیابان دهم فروردین",
                    Mobile = "09107602786",
                    Name = "رضا نصرتی",
                    PostalCode = "1764193683",
                    UserId = 1,

                }, cancellation);

                await _context.SaveAsync(cancellation);
            }

            if (!await _context.Orders.AnyAsync(cancellation))
            {
                await _context.Orders.AddAsync(new Order
                {
                    FinalAmount = 200000,
                    CreateDate = DateTime.Now,
                    DeliveryDate = DateTime.Now.AddDays(1),
                    DiscountPrice = 0,
                    UserAddressId = 1,
                    OrderStatus = OrderStatus.Pending,
                    ShipmentPrice = 5000,
                    OrderNumber = "RL-5696798",
                    DeliverPeriodTime = DeliverPeriodTime.NineToTwelve
                }, cancellation);

                await _context.SaveAsync(cancellation);
            }

            if (!await _context.OrderItems.AnyAsync(cancellation))
            {
                await _context.OrderItems.AddAsync(new OrderItem
                {
                    Count = 2,
                    CreateDate = DateTime.Now,
                    OrderId = 1,
                    Price = 900000,
                    ProductVariantId = 1,
                    UserId = 1
                }, cancellation);

                await _context.SaveAsync(cancellation);
            }

            if (!await _context.Comments.AnyAsync(cancellation))
            {
                await _context.Comments.AddAsync(new Comment
                {
                    Description = "خیلی محصول خوبی هستش",
                    CreateDate = DateTime.Now,
                    ProductId = 1,
                    UserId = 1,
                    IsConfirm = false,

                }, cancellation);

                await _context.SaveAsync(cancellation);
            }

            if (!await _context.BankTransactions.AnyAsync(cancellation))
            {
                await _context.BankTransactions.AddAsync(new BankTransaction
                {
                    CreateDate = DateTime.Now,
                    OrderId = 1,
                    Price = 195000,
                    RefId = 257678,
                    Status = 100,
                    Token = Guid.NewGuid().ToString("N"),
                }, cancellation);

                await _context.SaveAsync(cancellation);
            }

            if (!await _context.Statistics.AnyAsync(cancellation))
            {
                await _context.Statistics.AddAsync(new Statistic
                {
                    TotalBlog = 1,
                    TotalOrder = 1,
                    TotalUser = 1,
                    TotalView = 1,
                    TotalProduct = 1
                }, cancellation);

                await _context.SaveAsync(cancellation);
            }

            if (!await _context.DailyStatistics.AnyAsync(cancellation))
            {
                await _context.DailyStatistics.AddAsync(
                    new DailyStatistic
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTime.Now,
                        RegisterUser = 1,
                        TotalOrder = 1,
                        TotalRevenue = 200000,
                        TotalView = 1
                    }, cancellation);
                await _context.DailyStatistics.AddAsync(
                    new DailyStatistic
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTime.Now.AddDays(-1),
                        RegisterUser = 1,
                        TotalOrder = 1,
                        TotalRevenue = 0,
                        TotalView = 1
                    }, cancellation);
                await _context.DailyStatistics.AddAsync(
                    new DailyStatistic
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTime.Now.AddDays(-2),
                        RegisterUser = 0,
                        TotalOrder = 0,
                        TotalRevenue = 0,
                        TotalView = 2
                    }, cancellation);
                await _context.DailyStatistics.AddAsync(
                    new DailyStatistic
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTime.Now.AddDays(-3),
                        RegisterUser = 0,
                        TotalOrder = 0,
                        TotalRevenue = 0,
                        TotalView = 1
                    }, cancellation);


                await _context.SaveAsync(cancellation);
            }

            if (!await _context.AppSettings.AnyAsync(cancellation))
            {
                await _context.AppSettings.AddAsync(new AppSetting
                {
                    Title = "رزلند لاکچری",
                    MaxSlideShow = 4,
                    MaxSizeUploadFile = 3,
                    DefaultLanguageCode = "fa",
                    MaintenanceMode = false,
                }, cancellation);

                await _context.SaveAsync(cancellation);
            }


            if (!await _context.Notifications.AnyAsync(cancellation))
            {
                await _context.Notifications.AddAsync(new Notification
                {
                    CreateDate = DateTime.Now,
                    NotificationType = NotificationType.Message,
                    Description = "پیام جدید از طرف عادل مهربان",
                    IsRead = false,
                    IsDeleted = false

                }, cancellation);
                await _context.Notifications.AddAsync(new Notification
                {
                    CreateDate = DateTime.Now,
                    NotificationType = NotificationType.Message,
                    Description = "ثبت سفارش جدید از طرف نیما نصرتی",
                    IsRead = false,
                    IsDeleted = false

                }, cancellation);
                await _context.SaveAsync(cancellation);
            }
            #endregion

        }
    }
}
