using MediatR;
using Microsoft.Extensions.Logging;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger )
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        _logger.LogInformation($"[START] {request.GetType().Name}");

        var response = await next();
        _logger.LogInformation($"[END] {response.GetType().Name}");

        return response;
    }
}
