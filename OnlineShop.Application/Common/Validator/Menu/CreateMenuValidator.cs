using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Menu.Command.CreateMenu;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.Menu
{
    public class CreateMenuValidator : AbstractValidator<CreateMenuCommand>
    {
        private readonly ICmsDbContext _context;

        public CreateMenuValidator(ICmsDbContext context)
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

        private async Task<bool> ValidParent(CreateMenuCommand createMenuCommand, CancellationToken cancellationToken)
        {
            if (createMenuCommand.ParentId.HasValue)
                if (!await _context.Menus.AnyAsync(x => !x.IsDeleted && x.Id == createMenuCommand.ParentId, cancellationToken))
                    return false;

            return true;
        }


        private async Task<bool> ValidUniqueName(CreateMenuCommand createMenuCommand,
            CancellationToken cancellationToken)
            => !await _context.Menus.AnyAsync(x => !x.IsDeleted && x.UniqueName == createMenuCommand.UniqueName,
                cancellationToken);
    }
}