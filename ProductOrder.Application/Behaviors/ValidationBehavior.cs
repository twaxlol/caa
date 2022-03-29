using MediatR;
using FluentValidation;
using Microsoft.Extensions.Logging;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly ILogger<LoggingBehavior<TRequest,TResponse>> _logger;

    public ValidationBehavior(
        IEnumerable<IValidator<TRequest>> validators,
        ILogger<LoggingBehavior<TRequest,TResponse>> logger)
    {
        _validators = validators;
        _logger = logger;
    }
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if(!_validators.Any())
        {
            _logger.LogWarning($"[VALIDATION WARNING] No validators for {request.GetType().Name} was found");
            return await next();
        }
        
        _logger.LogInformation($"[VALIDATION START] {request.GetType().Name}");

        var validationContext  = new ValidationContext<TRequest>(request);
        var validationErrors = _validators
            .Select(x => x.Validate(validationContext))
            .SelectMany(x => x.Errors)
            .Where(x => x is not null)
            .ToList();


        if(validationErrors.Any())
        {
            _logger.LogError($"[VALIDATION ERROR] {validationErrors}");
            throw new ValidationException(validationErrors);
        }
        _logger.LogInformation($"[VALIDATION END] {request.GetType().Name}");
        return await next();
    }
}