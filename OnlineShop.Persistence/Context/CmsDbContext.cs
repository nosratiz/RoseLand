using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Shop;
using OnlineShop.Domain.Entities.statistic;
using OnlineShop.Domain.Entities.UserManagement;
using OnlineShop.Domain.Entities.UserManagment;

namespace OnlineShop.Persistence.Context
{
    public class CmsDbContext : DbContext, ICmsDbContext
    {
        protected CmsDbContext()
        {

        }

        public CmsDbContext(DbContextOptions<CmsDbContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserFile> UserFiles { get; set; }
        public virtual DbSet<HtmlPart> HtmlParts { get; set; }
        public virtual DbSet<BlogCategory> BlogCategories { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Faq> Faqs { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<ContactUs> ContactUses { get; set; }
        public virtual DbSet<AppSetting> AppSettings { get; set; }
        public virtual DbSet<SlideShow> SlideShows { get; set; }
        public virtual DbSet<Subscribe> Subscribes { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Statistic> Statistics { get; set; }
        public virtual DbSet<DailyStatistic> DailyStatistics { get; set; }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<BankTransaction> BankTransactions { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        public virtual DbSet<ProductPriceHistory> ProductPriceHistories { get; set; }
        public virtual DbSet<ProductGallery> ProductGalleries { get; set; }
        public virtual DbSet<DiscountCode> DiscountCodes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ProductVariant> ProductVariants { get; set; }

        public virtual DbSet<Notification> Notifications { get; set; }

        public virtual DbSet<ShopStatistic> ShopStatistics { get; set; }

        public virtual DbSet<UserDiscountCode> UserDiscountCodes { get; set; }

        public Task SaveAsync(CancellationToken cancellationToken) => base.SaveChangesAsync(cancellationToken);

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(CmsDbContext).Assembly);

    }
}