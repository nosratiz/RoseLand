using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Shop.DiscountCodes.Command.CreateDiscountCode;
using OnlineShop.Application.Shop.DiscountCodes.Command.DeleteDiscountCode;
using OnlineShop.Application.Shop.DiscountCodes.Command.UpdateDiscountCode;

namespace OnlineShop.UI.Areas.AdminApi.Controllers
{
    public class DiscountCodeController : BaseApiController
    {

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteDiscountCodeCommand {Id = id});

            return result.ApiResult;
        }


        [HttpPost]
        public async Task<IActionResult> AddDiscountCode(CreateDiscountCodeCommand createDiscountCode)
        {
            var result = await Mediator.Send(createDiscountCode);

            return result.ApiResult;
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCode(UpdateDiscountCodeCommand updateDiscountCode)
        {
            var result = await Mediator.Send(updateDiscountCode);

            return result.ApiResult;
        }
    }
}