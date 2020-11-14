using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Shop;
using OnlineShop.Domain.Entities.statistic;
using OnlineShop.Domain.Entities.UserManagement;
using OnlineShop.Domain.Entities.UserManagment;

namespace OnlineShop.Application.Common.Interface
{
    public interface ICmsDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Domain.Entities.UserManagement.UserFile> UserFiles { get; set; }
        DbSet<Blog> Blogs { get; set; }
        DbSet<BlogCategory> BlogCategories { get; set; }
        DbSet<Faq> Faqs { get; set; }
        DbSet<HtmlPart> HtmlParts { get; set; }
        DbSet<ContactUs> ContactUses { get; set; }
        DbSet<Menu> Menus { get; set; }
        DbSet<SlideShow> SlideShows { get; set; }
        DbSet<AppSetting> AppSettings { get; set; }
        DbSet<UserToken> UserTokens { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Domain.Entities.statistic.Statistic> Statistics { get; set; }
        DbSet<DailyStatistic> DailyStatistics { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Domain.Entities.Shop.UserAddress> UserAddresses { get; set; }
        DbSet<BankTransaction> BankTransactions { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        DbSet<ProductPriceHistory> ProductPriceHistories { get; set; }
        DbSet<ProductGallery> ProductGalleries { get; set; }
        DbSet<DiscountCode> DiscountCodes { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<ProductVariant> ProductVariants { get; set; }

        DbSet<Notification> Notifications { get; set; }

        DbSet<ShopStatistic> ShopStatistics { get; set; }

        DbSet<UserDiscountCode> UserDiscountCodes { get; set; }

        Task SaveAsync(CancellationToken cancellationToken);

    }
}