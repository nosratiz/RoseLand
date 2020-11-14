using System.Threading.Tasks;

namespace OnlineShop.Common.EmailService
{
    public interface IEmailServices
    {
        Task SendMessage(string emailTo, string subject, string body);
    }
}