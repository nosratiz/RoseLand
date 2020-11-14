using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.UserFile.Command;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Options;

namespace OnlineShop.Application.Common.Validator.File
{
    public class UploadFileCommandValidator : AbstractValidator<UploadFileCommand>
    {
        private readonly Extensions _extensions;
        private readonly ICmsDbContext _context;
        public UploadFileCommandValidator(IOptions<Extensions> extensions, ICmsDbContext context)
        {
            _context = context;
            _extensions = extensions.Value;


            RuleFor(dto => dto).Cascade(CascadeMode.StopOnFirstFailure)
                .Must(ValidExtension).WithMessage(ResponseMessage.FileExtensionNotSupported)
               /* .MustAsync(ValidSize).WithMessage(ResponseMessage.MaxSizeReach)*/;
        }

        private bool ValidExtension(UploadFileCommand uploadFileCommand)
        {
            foreach (var item in uploadFileCommand.Files)
            {
                if (item == null || item.Length == 0)
                    return false;

                var fileExtension = Path.GetExtension(item.FileName);

                if (!_extensions.ValidFormat.Exists(x => x == fileExtension))
                    return false;
            }

            return true;
        }


        private async Task<bool> ValidSize(UploadFileCommand uploadFileCommand, CancellationToken cancellationToken)
        {
            var appSetting = await _context.AppSettings.FirstOrDefaultAsync(cancellationToken);

            foreach (var item in uploadFileCommand.Files)
                if (item.Length > appSetting.MaxSizeUploadFile)
                    return false;

            return true;
        }
    }
}