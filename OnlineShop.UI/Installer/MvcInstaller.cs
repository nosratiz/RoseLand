using System.IO;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions;
using Microsoft.Extensions.FileProviders;
using OnlineShop.Application.Common.AutoMapper;
using OnlineShop.Application.Common.Interface;
using OnlineShop.UI.Middleware;

namespace OnlineShop.UI.Installer
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                    builder => { builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod(); });
            });

            services.AddMemoryCache();

            services.AddHttpContextAccessor();


            #region Automapper

            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion Automapper

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = new PathString("/signin");
                    options.Cookie.HttpOnly = true;
                    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                    options.SlidingExpiration = true;
                });


            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllersWithViews(opt => { opt.Filters.Add<OnExceptionMiddleware>(); })
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<ICmsDbContext>();
                    fv.ImplicitlyValidateChildProperties = true;
                })
                .AddRazorRuntimeCompilation();

            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
        }
    }
}