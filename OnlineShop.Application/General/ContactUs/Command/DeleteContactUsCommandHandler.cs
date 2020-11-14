using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.ContactUs.Command
{
    public class DeleteContactUsCommandHandler : IRequestHandler<DeleteContactUsCommand, Result>
    {
        private readonly ICmsDbContext _context;

        public DeleteContactUsCommandHandler(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(DeleteContactUsCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.ContactUses.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (result is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.ContentNotFound)));


            _context.ContactUses.Remove(result);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull();
        }
    }
}