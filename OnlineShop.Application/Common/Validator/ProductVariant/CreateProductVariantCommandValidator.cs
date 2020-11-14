using FluentValidation;
using OnlineShop.Application.Shop.ProductVariants.Command.CreateCommand;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.ProductVariant
{
    public class CreateProductVariantCommandValidator : AbstractValidator<CreateProductVariantCommand>
    {
        public CreateProductVariantCommandValidator()
        {
            RuleFor(dto => dto.Price).NotEmpty().WithMessage(ResponseMessage.PriceIsRequired);

            RuleFor(dto => dto.Count).NotEmpty().WithMessage(ResponseMessage.CountIsRequired);


        }
    }
}