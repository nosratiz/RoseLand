using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Shop.Products.Command.CreateProduct;
using OnlineShop.Application.Shop.Products.Command.DeleteProduct;
using OnlineShop.Application.Shop.Products.Command.UpdateProduct;

namespace OnlineShop.UI.Areas.AdminApi.Controllers
{
    public class ProductController : BaseApiController
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteProductCommand { Id = id });

            return result.ApiResult;
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateProductCommand createProduct)
        {
            var result = await Mediator.Send(createProduct);

            return result.ApiResult;
        }


        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductCommand updateProductCommand)
        {
            var result = await Mediator.Send(updateProductCommand);

            return result.ApiResult;
        }
    }
}