using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using OnlineShop.Application.Authentication.Command;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.Auth
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordValidator()
        {

            RuleFor(dto => dto.OldPassword).NotEmpty().WithMessage(ResponseMessage.PasswordIsRequired);

            RuleFor(dto => dto.NewPassword).NotEmpty();
        }



    }
}