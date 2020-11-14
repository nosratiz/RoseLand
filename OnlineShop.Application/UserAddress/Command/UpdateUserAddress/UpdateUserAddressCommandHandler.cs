using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.UserAddress.Command.UpdateUserAddress
{
    public class UpdateUserAddressCommandHandler : IRequestHandler<UpdateUserAddressCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUserAddressCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateUserAddressCommand request, CancellationToken cancellationToken)
        {
            var userAddress = await _context.UserAddresses.SingleOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);


            if (userAddress is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.UserAddressNotFound)));


            _mapper.Map(request, userAddress);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.UpdateSuccessfully)));
        }
    }
}