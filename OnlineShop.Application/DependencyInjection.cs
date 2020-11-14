using System.Linq;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Cart;
using OnlineShop.Application.Common.Interface.Statistic;
using OnlineShop.Application.Common.Services;

namespace OnlineShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddTransient<IStatisticService, StatisticService>();

            services.AddTransient<IDailyStatistic, DailyStatisticService>();

            services.AddTransient<IShoppingCartService, ShoppingCartService>();

            services.AddTransient<IZarinPalService, ZarinPalService>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                //options.SuppressModelStateInvalidFilter = true;
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = new
                    {
                        message =
                            actionContext.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage.ToString())
                                .FirstOrDefault()

                    };
                    return new BadRequestObjectResult(errors);
                };
            });

            return services;
        }
    }
}