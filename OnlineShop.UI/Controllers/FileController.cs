using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.UserFile.Command;

namespace OnlineShop.UI.Controllers {
    [Route ("[Controller]")]
    [ApiController]
    [EnableCors ("MyPolicy")]
    public class FileController : BaseController {
        [HttpPost]
        [Consumes ("multipart/form-data")]
        [Route ("[Action]")]
        public async Task<IActionResult> Upload ([FromForm] UploadFileCommand uploadFileCommand) {

            var result = await Mediator.Send (uploadFileCommand);

            return result.ApiResult;
        }
    }
}