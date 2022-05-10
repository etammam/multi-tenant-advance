using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;
using MultiTenant.Catalog.Core.Common;

namespace MultiTenant.Catalog.Core.Behaviors;

public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ICurrentUserService _currentUser;
    private readonly ILogger _logger;
    private readonly Stopwatch _timer;

    public PerformanceBehavior(
        Stopwatch timer,
        ILogger logger,
        ICurrentUserService currentUser)
    {
        _timer = timer;
        _logger = logger;
        _currentUser = currentUser;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        _timer.Start();
        var response = await next();
        _timer.Stop();
        var elapsedMilliseconds = _timer.ElapsedMilliseconds;
        if (elapsedMilliseconds > 500)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUser.UserId().ToString() ?? string.Empty;
            var userName = string.Empty;

            if (!string.IsNullOrEmpty(userId)) userName = _currentUser.UserName();

            _logger.LogWarning(
                "Tenant Catalog Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
                requestName, elapsedMilliseconds, userId, userName, request);
        }

        return response;
    }
}