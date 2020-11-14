using MediatR;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.Comments.Command.ConfirmCommentCommand
{
    public class ConfirmCommentCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}