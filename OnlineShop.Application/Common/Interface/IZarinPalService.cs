using System.Threading.Tasks;
using Zarinpal.Models;

namespace OnlineShop.Application.Common.Interface
{
    public interface IZarinPalService
    {
        Task<PaymentRequestResponse> PaymentRequest(long orderId, int price);

        Task<PaymentVerificationResponse> VerifyPayment(string authority, int price);
    }
}