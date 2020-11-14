using FluentValidation;
using OnlineShop.Application.Authentication.Command;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.Auth
{
    public class ForgetPasswordValidator : AbstractValidator<ForgetPasswordCommand>
    {
        public ForgetPasswordValidator()
        {
            RuleFor(dto => dto.Email).NotEmpty().WithMessage(ResponseMessage.EmptyEmail)
                .EmailAddress().WithMessage(ResponseMessage.InvalidEmailAddress);
        }
    }
}