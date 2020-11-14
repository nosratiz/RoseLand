using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.BlogCategory.Command.CreateCategory;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.BlogCategory
{
    public class CreateBlogCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICmsDbContext _context;

        public CreateBlogCategoryValidator(ICmsDbContext context)
        {
            _context = context;

            RuleFor(dto => dto.Name).NotEmpty().WithMessage(ResponseMessage.NameIsRequired);


            RuleFor(dto => dto)
                .MustAsync(ValidSlug).WithMessage(ResponseMessage.InvalidBlogCategorySlug)
                .MustAsync(ValidParent).WithMessage(ResponseMessage.ParentNotFound);
        }

        private async Task<bool> ValidSlug(CreateCategoryCommand categoryCommand, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(categoryCommand.Slug))
                if (await _context.BlogCategories.AnyAsync(x => x.Slug == categoryCommand.Slug && !x.IsDeleted, cancellationToken))
                    return false;


            return true;

        }

        private async Task<bool> ValidParent(CreateCategoryCommand createCategoryCommand,
            CancellationToken cancellationToken)
        {
            if (createCategoryCommand.ParentId.HasValue)
                if (!await _context.BlogCategories.AnyAsync(
                    x => !x.IsDeleted && x.Id == createCategoryCommand.ParentId.Value, cancellationToken))
                    return false;


            return true;
        }



    }


}