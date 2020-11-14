using FluentValidation;
using OnlineShop.Application.General.ContactUs.Command;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.ContactUs
{
    public class CreateContactUsValidator :AbstractValidator<CreateContactUsCommand>
    {
        public CreateContactUsValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().WithMessage(ResponseMessage.NameIsRequired);

            RuleFor(dto => dto.Email).NotEmpty().WithMessage(ResponseMessage.EmptyEmail)
                .EmailAddress().WithMessage(ResponseMessage.InvalidEmailAddress);

            RuleFor(dto => dto.Message).NotEmpty().WithMessage(ResponseMessage.MessageIsRequired);
        }
    }
}