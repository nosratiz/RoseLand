using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.SlideShow.Command.UpdateSlideShow
{
    public class UpdateSlideShowCommandHandler : IRequestHandler<UpdateSlideShowCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public UpdateSlideShowCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateSlideShowCommand request, CancellationToken cancellationToken)
        {
            var slideShow = await _context.SlideShows.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (slideShow is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.SlideShowNotFound)));

            _mapper.Map(request, slideShow);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new ObjectResult(new ApiMessage(ResponseMessage.UpdateSuccessfully)));
        }
    }
}