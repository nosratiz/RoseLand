using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Persistence.Context;

namespace OnlineShop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CmsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CmsDbContext")));

            services.AddScoped<ICmsDbContext>(provider => provider.GetService<CmsDbContext>());

            return services;
        }
    }
}