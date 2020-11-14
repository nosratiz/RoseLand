using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.Common.Interface;

namespace OnlineShop.Application.Common.Behaviors
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;

        public RequestLogger(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            _logger.LogInformation("Cms Request: {Name} {@UserId} {@Request}", 
                name, _currentUserService.UserId, request);

            return Task.CompletedTask;
        }
    }
}
