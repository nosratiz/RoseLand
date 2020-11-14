using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.SlideShow.Command.DeleteSlideShow
{
    public class DeleteSlideShowCommandHandler : IRequestHandler<DeleteSlideShowCommand, Result>
    {
        private readonly ICmsDbContext _context;

        public DeleteSlideShowCommandHandler(ICmsDbContext context)
        {
            _context = context;
        }
        public async Task<Result> Handle(DeleteSlideShowCommand request, CancellationToken cancellationToken)
        {
            var slideShow = await _context.SlideShows.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (slideShow is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.SlideShowNotFound)));

            _context.SlideShows.Remove(slideShow);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull();
        }
    }
}