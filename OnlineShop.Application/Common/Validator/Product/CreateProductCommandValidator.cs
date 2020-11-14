using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Products.Command.CreateProduct;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.Product
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly ICmsDbContext _context;

        public CreateProductCommandValidator(ICmsDbContext context)
        {
            _context = context;

            RuleFor(dto => dto.Name).NotEmpty().WithMessage(ResponseMessage.NameIsRequired);

            RuleFor(dto => dto.Image).NotEmpty().WithMessage(ResponseMessage.ImageIsRequired);

            RuleFor(dto => dto.Description).NotEmpty().WithMessage(ResponseMessage.DescriptionIsRequired);

            RuleFor(dto => dto).MustAsync(ValidCategory).WithMessage(ResponseMessage.CategoryNotFound)
                .MustAsync(ValidSlug).WithMessage(ResponseMessage.SlugExist);


        }


        private async Task<bool> ValidCategory(CreateProductCommand createProductCommand,
            CancellationToken cancellationToken)
        {
            if (!await _context.ProductCategories.AnyAsync(x => !x.IsDeleted && x.Id == createProductCommand.ProductCategoryId, cancellationToken))
                return false;

            return true;
        }

        private async Task<bool> ValidSlug(CreateProductCommand createProductCommand,
            CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(createProductCommand.Slug))
                if (await _context.Products.AnyAsync(x => x.Slug == createProductCommand.Slug, cancellationToken))
                    return false;

            return true;

        }
    }
}