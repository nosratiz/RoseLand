using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using Zarinpal;
using Zarinpal.Models;

namespace OnlineShop.Application.Common.Services
{
    public class ZarinPalService : IZarinPalService
    {
        private readonly ICmsDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public ZarinPalService(ICmsDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PaymentRequestResponse> PaymentRequest(long orderId, int price)
        {

            var appSetting = await _context.AppSettings.FirstOrDefaultAsync();

            var payment = new Zarinpal.Payment(appSetting.MerchantId, (price));

            var result = await payment.PaymentRequest(appSetting.Title,
                $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/payment/verification?orderId={orderId}");

            return result;
        }

        public async Task<PaymentVerificationResponse> VerifyPayment(string authority, int price)
        {
            var appSetting = await _context.AppSettings.FirstOrDefaultAsync();

            var payment = new Payment(appSetting.MerchantId, price);

            var result = await payment.Verification(authority);

            return result;
        }
    }
}