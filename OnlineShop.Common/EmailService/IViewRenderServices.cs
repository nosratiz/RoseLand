using System.Threading.Tasks;

namespace OnlineShop.Common.EmailService
{
    public interface IViewRenderServices
    {
        Task<string> RenderToStringAsync(string viewName, object model);
    }
}