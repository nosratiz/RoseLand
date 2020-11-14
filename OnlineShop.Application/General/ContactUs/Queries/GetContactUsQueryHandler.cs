using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.ContactUs.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.ContactUs.Queries
{
    public class GetContactUsQueryHandler : IRequestHandler<GetContactUsQuery, Result<ContactUsDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetContactUsQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ContactUsDto>> Handle(GetContactUsQuery request, CancellationToken cancellationToken)
        {
            var contactUs = await _context.ContactUses.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (contactUs is null)
                return Result<ContactUsDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.ContentNotFound)));

            return Result<ContactUsDto>.SuccessFull(_mapper.Map<ContactUsDto>(contactUs));
        }
    }
}