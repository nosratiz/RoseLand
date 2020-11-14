using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OnlineShop.Application.Common.Interface;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.System
{
    public class SampleSeedDataCommand : IRequest
    {
    }

    public class SampleSeedDataCommandHandler :IRequestHandler<SampleSeedDataCommand>
    {
        private readonly ICmsDbContext _context;

        public SampleSeedDataCommandHandler(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SampleSeedDataCommand request, CancellationToken cancellationToken)
        {
           var seeder=new SeedData(_context);

           await seeder.SeedAllAsync(cancellationToken);

           return Unit.Value;
        }
    }
}
