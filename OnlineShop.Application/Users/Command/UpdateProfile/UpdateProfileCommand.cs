using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.UserManagement;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Users.Command.UpdateProfile
{
    public class UpdateProfileCommand : IRequest<Result<User>>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Family { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }


    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, Result<User>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public UpdateProfileCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<User>> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.Id && x.Status != Status.Delete, cancellationToken);

            if (user is null)
                return Result<User>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.UserNotFound)));

            _mapper.Map(request, user);

            await _context.SaveAsync(cancellationToken);


            return Result<User>.SuccessFull(user);
        }
    }
}