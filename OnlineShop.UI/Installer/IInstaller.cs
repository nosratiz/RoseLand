using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineShop.UI.Installer
{
    public interface IInstaller
    {
        void InstallServices(IConfiguration configuration, IServiceCollection services);
    }
}