using MediatR;
using OnlineShop.Application.Shop.Comments.ModelDto;
using OnlineShop.Common.Result;


namespace OnlineShop.Application.Shop.Comments.Command.ReplyCommentCommand
{
    public class ReplyCommentCommand : IRequest<Result<CommentDto>>
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}