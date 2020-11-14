using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.UserAddress.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.UserAddress.Command.CreateUserAddress
{
    public class CreateUserAddressCommandHandler : IRequestHandler<CreateUserAddressCommand, Result<UserAddressDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateUserAddressCommandHandler(ICmsDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Result<UserAddressDto>> Handle(CreateUserAddressCommand request, CancellationToken cancellationToken)
        {
            var userAddress = _mapper.Map<Domain.Entities.Shop.UserAddress>(request);

            userAddress.UserId = int.Parse(_currentUserService.UserId);

            await _context.UserAddresses.AddAsync(userAddress, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return Result<UserAddressDto>.SuccessFull(_mapper.Map<UserAddressDto>(userAddress));
        }
    }
}