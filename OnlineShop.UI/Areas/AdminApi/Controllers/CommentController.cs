using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Shop.Comments.Command.ConfirmCommentCommand;
using OnlineShop.Application.Shop.Comments.Command.DeleteCommentCommand;
using OnlineShop.Application.Shop.Comments.Command.ReplyCommentCommand;
using OnlineShop.Application.Shop.Comments.Queries;

namespace OnlineShop.UI.Areas.AdminApi.Controllers
{
    public class CommentController : BaseApiController
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteCommentCommand { Id = id });

            return result.ApiResult;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ConfirmComment(int id)
        {
            var result = await Mediator.Send(new ConfirmCommentCommand { Id = id });

            return result.ApiResult;
        }

        [HttpPost]
        public async Task<IActionResult> ReplyComment(ReplyCommentCommand replyCommentCommand)
        {
            var result = await Mediator.Send(replyCommentCommand);

            return result.ApiResult;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Mediator.Send(new GetCommentQuery {Id = id});

            return result.ApiResult;
        }
    }
}