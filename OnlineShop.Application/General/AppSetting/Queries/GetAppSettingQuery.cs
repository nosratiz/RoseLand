using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.AppSetting.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.AppSetting.Queries
{
    public class GetAppSettingQuery : IRequest<Result<AppSettingDto>>
    {

    }

    public class GetAppSettingQueryHandler : IRequestHandler<GetAppSettingQuery, Result<AppSettingDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetAppSettingQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<AppSettingDto>> Handle(GetAppSettingQuery request, CancellationToken cancellationToken)
        {
            var appSetting = await _context.AppSettings.FirstOrDefaultAsync(cancellationToken);

            return Result<AppSettingDto>.SuccessFull(_mapper.Map<AppSettingDto>(appSetting));
        }
    }
}