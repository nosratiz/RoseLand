using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Products.Command.CreateProduct;
using OnlineShop.Application.Shop.Products.Command.UpdateProduct;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.Product
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly ICmsDbContext _context;

        public UpdateProductCommandValidator(ICmsDbContext context)
        {
            _context = context;

            RuleFor(dto => dto.Name).NotEmpty().WithMessage(ResponseMessage.NameIsRequired);

            RuleFor(dto => dto.Image).NotEmpty().WithMessage(ResponseMessage.ImageIsRequired);

            RuleFor(dto => dto.Slug).NotEmpty().WithMessage(ResponseMessage.SlugIsRequired);

            RuleFor(dto => dto.Description).NotEmpty().WithMessage(ResponseMessage.DescriptionIsRequired);

            RuleFor(dto => dto).MustAsync(ValidCategory).WithMessage(ResponseMessage.CategoryNotFound)
                .MustAsync(ValidSlug).WithMessage(ResponseMessage.SlugExist);
        }

        private async Task<bool> ValidCategory(UpdateProductCommand updateProductCommand,
            CancellationToken cancellationToken)
        {
            if (!await _context.ProductCategories.AnyAsync(x => !x.IsDeleted && x.Id == updateProductCommand.ProductCategoryId, cancellationToken))
                return false;

            return true;
        }

        private async Task<bool> ValidSlug(UpdateProductCommand updateProductCommand,
            CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(updateProductCommand.Slug))
                if (await _context.Products.AnyAsync(x => x.Id != updateProductCommand.Id && x.Slug == updateProductCommand.Slug, cancellationToken))
                    return false;

            return true;

        }
    }
}