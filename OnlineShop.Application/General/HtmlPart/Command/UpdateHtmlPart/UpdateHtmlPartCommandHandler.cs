using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.HtmlPart.Command.UpdateHtmlPart
{
    public class UpdateHtmlPartCommandHandler : IRequestHandler<UpdateHtmlPartCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public UpdateHtmlPartCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateHtmlPartCommand request, CancellationToken cancellationToken)
        {
            var htmlPart = await _context.HtmlParts.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (htmlPart is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.ContentNotFound)));

            _mapper.Map(request, htmlPart);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull();
        }
    }
}