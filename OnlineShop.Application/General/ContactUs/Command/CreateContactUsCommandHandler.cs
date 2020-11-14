using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.ContactUs.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.ContactUs.Command
{
    public class CreateContactUsCommandHandler : IRequestHandler<CreateContactUsCommand, Result<ContactUsDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public CreateContactUsCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ContactUsDto>> Handle(CreateContactUsCommand request, CancellationToken cancellationToken)
        {
            var contactUs = _mapper.Map<Domain.Entities.ContactUs>(request);

            await _context.ContactUses.AddAsync(contactUs, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return Result<ContactUsDto>.SuccessFull(_mapper.Map<ContactUsDto>(contactUs));
        }
    }
}