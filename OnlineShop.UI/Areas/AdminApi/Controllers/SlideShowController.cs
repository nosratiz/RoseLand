using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.General.SlideShow.Command.CreateSlideShow;
using OnlineShop.Application.General.SlideShow.Command.DeleteSlideShow;
using OnlineShop.Application.General.SlideShow.Command.UpdateSlideShow;

namespace OnlineShop.UI.Areas.AdminApi.Controllers
{
    public class SlideShowController : BaseApiController
    {

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteSlideShowCommand { Id = id });

            return result.ApiResult;
        }



        [HttpPost]
        public async Task<IActionResult> Post(CreateSlideShowCommand createSlideShowCommand)
        {
            var result = await Mediator.Send(createSlideShowCommand);

            return result.ApiResult;
        }


        [HttpPut]
        public async Task<IActionResult> Put(UpdateSlideShowCommand updateSlideShowCommand)
        {
            var result = await Mediator.Send(updateSlideShowCommand);

            return result.ApiResult;
        }
    }
}