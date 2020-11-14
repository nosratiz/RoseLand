using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.Comments.Command.CreateCommentCommand
{
    public class CreateCommentCommand : IRequest<Result>
    {
        public string Description { get; set; }

        public int ProductId { get; set; }
    }


    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Result>
    {
        private readonly ICmsDbContext _contex;
        private readonly ICurrentUserService _currentUserService;

        public CreateCommentCommandHandler(ICmsDbContext contex, ICurrentUserService currentUserService)
        {
            _contex = contex;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await _contex.Comments.AddAsync(new Comment
            {
                Description = request.Description,
                UserId = int.Parse(_currentUserService.UserId),
                CreateDate = DateTime.Now,
                ProductId = request.ProductId
            },cancellationToken);


            await _contex.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.CommentAdded)));
        }
    }
}