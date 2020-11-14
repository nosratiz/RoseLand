using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Menu.Command.UpdateMenu;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.Menu
{
    public class UpdateMenuValidator : AbstractValidator<UpdateMenuCommand>
    {
        private readonly ICmsDbContext _context;
        public UpdateMenuValidator(ICmsDbContext context)
        {
            _context = context;

            RuleFor(dto => dto.Title)
                .NotEmpty().WithMessage(ResponseMessage.TitleIsRequired);

            RuleFor(dto => dto.UniqueName)
                .NotEmpty().WithMessage(ResponseMessage.NameIsRequired);

            RuleFor(dto => dto.SortOrder)
                .NotEmpty().WithMessage(ResponseMessage.SortOrderIsRequired);


            RuleFor(dto => dto).MustAsync(ValidParent)
                .WithMessage(ResponseMessage.ParentNotFound).MustAsync(ValidUniqueName)
                .WithMessage(ResponseMessage.DuplicateName);
        }

        private async Task<bool> ValidParent(UpdateMenuCommand updateMenuCommand, CancellationToken cancellationToken)
        {
            if (updateMenuCommand.ParentId.HasValue)
                if (!await _context.Menus.AnyAsync(x => !x.IsDeleted && x.Id == updateMenuCommand.ParentId, cancellationToken))
                    return false;

            return true;
        }


        private async Task<bool> ValidUniqueName(UpdateMenuCommand updateMenuCommand,
            CancellationToken cancellationToken)
            => !await _context.Menus.AnyAsync(x => !x.IsDeleted && x.UniqueName == updateMenuCommand.UniqueName && x.Id != updateMenuCommand.Id,
                cancellationToken);
    }
}