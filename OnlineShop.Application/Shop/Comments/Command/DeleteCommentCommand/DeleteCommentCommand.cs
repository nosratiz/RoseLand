using MediatR;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.Comments.Command.DeleteCommentCommand
{
    public class DeleteCommentCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}