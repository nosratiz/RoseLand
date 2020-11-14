using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Faq.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Faq.Command
{
    public class CreateFaqCommandHandler : IRequestHandler<CreateFaqCommand, Result<FaqDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public CreateFaqCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<FaqDto>> Handle(CreateFaqCommand request, CancellationToken cancellationToken)
        {
            var faq = _mapper.Map<Domain.Entities.Faq>(request);

            await _context.Faqs.AddAsync(faq, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return Result<FaqDto>.SuccessFull(_mapper.Map<FaqDto>(faq));
        }
    }
}