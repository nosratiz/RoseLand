using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Shop.ProductVariants.Command.CreateCommand;
using OnlineShop.Application.Shop.ProductVariants.Command.DeleteCommand;
using OnlineShop.Application.Shop.ProductVariants.Command.UpdateCommand;

namespace OnlineShop.UI.Areas.AdminApi.Controllers
{
    public class ProductVariantController : BaseApiController
    {

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteProductVariantCommand { Id = id });

            return result.ApiResult;
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateProductVariantCommand createProductVariantCommand)
        {
            var result = await Mediator.Send(createProductVariantCommand);

            return result.ApiResult;
        }


        [HttpPut]
        public async Task<IActionResult> Edit(UpdateProductVariantCommand updateProductVariantCommand)
        {
            var result = await Mediator.Send(updateProductVariantCommand);

            return result.ApiResult;
        }
    }
}