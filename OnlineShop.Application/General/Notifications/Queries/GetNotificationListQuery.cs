using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Notifications.ModelDto;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.General.Notifications.Queries
{
    public class GetNotificationListQuery : PagingOptions, IRequest<Result<List<NotificationDto>>>
    {

    }

    public class GetNotificationListQueryHandler : IRequestHandler<GetNotificationListQuery, Result<List<NotificationDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetNotificationListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<List<NotificationDto>>> Handle(GetNotificationListQuery request, CancellationToken cancellationToken)
        {
            var notificationList = await _context.Notifications.Where(x => !x.IsDeleted && !x.IsRead)
                .OrderByDescending(x => x.CreateDate).Take(request.Limit).ToListAsync(cancellationToken);


            return Result<List<NotificationDto>>.SuccessFull(_mapper.Map<List<NotificationDto>>(notificationList));
        }
    }
}