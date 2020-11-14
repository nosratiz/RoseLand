using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Menu.Command.DeleteMenu
{
    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, Result>
    {
        private readonly ICmsDbContext _context;

        public DeleteMenuCommandHandler(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await _context.Menus.SingleOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);

            if (menu is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.MenuNotFound)));

            if (menu.IsVital)
                return Result.Failed(new BadRequestObjectResult(new ApiMessage(ResponseMessage.IsVital)));
            

            menu.IsDeleted = true;
            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.DeleteSuccessfully)));
        }
    }
}