using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.BlogCategory.Command.UpdateCategory;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.BlogCategory
{
    public class UpdateBlogCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly ICmsDbContext _context;

        public UpdateBlogCategoryValidator(ICmsDbContext context)
        {
            _context = context;

            RuleFor(dto => dto.Name).NotEmpty().WithMessage(ResponseMessage.NameIsRequired);

            RuleFor(dto => dto)
                .MustAsync(ValidSlug).WithMessage(ResponseMessage.InvalidBlogCategorySlug)
                .MustAsync(ValidParent).WithMessage(ResponseMessage.ParentNotFound).Must(dto => dto.Id != dto.ParentId)
                .WithMessage(ResponseMessage.ParentAndChildrenSame);

        }

        private async Task<bool> ValidSlug(UpdateCategoryCommand updateCategoryCommand, CancellationToken cancellationToken)
            => !await _context.BlogCategories.AnyAsync(x => x.Slug == updateCategoryCommand.Slug && !x.IsDeleted && x.Id != updateCategoryCommand.Id,
                cancellationToken);


        private async Task<bool> ValidParent(UpdateCategoryCommand updateCategoryCommand,
            CancellationToken cancellationToken)
        {
            if (updateCategoryCommand.ParentId.HasValue)
                if (!await _context.BlogCategories.AnyAsync(x => !x.IsDeleted && x.Id == updateCategoryCommand.ParentId.Value, cancellationToken))
                    return false;

            return true;
        }
    }
}