using FluentValidation;
using OnlineShop.Application.Authentication.Command;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.Auth
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(dto => dto.Email).NotEmpty().WithMessage(ResponseMessage.EmptyEmail);

            RuleFor(dto => dto.Password).NotEmpty().WithMessage(ResponseMessage.PasswordIsRequired);
        }
    }
}