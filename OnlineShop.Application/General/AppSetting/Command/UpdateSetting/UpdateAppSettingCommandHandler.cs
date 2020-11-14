using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.AppSetting.Command.UpdateSetting
{
    public class UpdateAppSettingCommandHandler : IRequestHandler<UpdateAppSettingCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAppSettingCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateAppSettingCommand request, CancellationToken cancellationToken)
        {
            var appSetting = await _context.AppSettings.FirstOrDefaultAsync(cancellationToken);

            _mapper.Map(request, appSetting);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new ObjectResult(new ApiMessage(ResponseMessage.UpdateSuccessfully)));
        }
    }
}