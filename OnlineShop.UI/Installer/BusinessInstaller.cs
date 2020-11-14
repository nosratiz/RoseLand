using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.EmailService;
using OnlineShop.Common.ImageProcessor;
using OnlineShop.Common.Options;
using OnlineShop.UI.Core;
using OnlineShop.UI.Core.Data;
using OnlineShop.UI.Core.Service;
using OnlineShop.UI.Filter;

namespace OnlineShop.UI.Installer
{
    public class BusinessInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));

            services.Configure<Extensions>(configuration.GetSection("Extensions"));

            services.Configure<ImageSetting>(configuration.GetSection("ImageSetting"));

            services.Configure<HostAddress>(configuration.GetSection("HostAddress"));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IImageProcessorService, ImageProcessorService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IEmailServices, EmailServices>();
            services.AddTransient<IRequestMeta, RequestMeta>();
            services.AddTransient<IViewRenderServices, ViewRenderServices>();

            services.AddSingleton<IApplicationBootstrapper, ApplicationBootstrapper>();
            

            services.AddTransient<AdminAuthorization>();
        }
    }
}