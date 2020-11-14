using System;
using FluentValidation;
using OnlineShop.Application.General.SlideShow.Command.CreateSlideShow;
using OnlineShop.Application.General.SlideShow.Command.UpdateSlideShow;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.SlideShow
{
    public class UpdateSlideShowValidator :AbstractValidator<UpdateSlideShowCommand>
    {
        public UpdateSlideShowValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().WithMessage(ResponseMessage.NameIsRequired);

            RuleFor(dto => dto.Title).NotEmpty().WithMessage(ResponseMessage.TitleIsRequired);

            RuleFor(dto => dto.Image).NotEmpty().WithMessage(ResponseMessage.ImageIsRequired);

            RuleFor(dto => dto).Must(ValidDateTime).WithMessage(ResponseMessage.InvalidDateTime);

        }

        private bool ValidDateTime(UpdateSlideShowCommand createDiscountCode)
        {
            if (!string.IsNullOrWhiteSpace(createDiscountCode.StartDateTime) || !string.IsNullOrWhiteSpace(createDiscountCode.EndDateTime))
            {
                try
                {
                    var startDate = DateTimeConvertor.ToGregorianDateTime(createDiscountCode.StartDateTime);
                    var endDate = DateTimeConvertor.ToGregorianDateTime(createDiscountCode.EndDateTime);

                    if (startDate > endDate)
                        return false;

                }
                catch (Exception)
                {
                    return false;
                }
            }

            return true;
        }
    }
}