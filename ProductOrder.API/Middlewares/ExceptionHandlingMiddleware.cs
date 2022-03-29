using System.Text.Json;
using FluentValidation;

internal sealed class ExcpetionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExcpetionHandlingMiddleware> _logger;
    public ExcpetionHandlingMiddleware(ILogger<ExcpetionHandlingMiddleware> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try 
        {
            await next(context);
        }
        catch(Exception e)
        {
            _logger.LogError(e, $"[MIDDLEWARE EXCEPTION] {e.Message}");
            await HandleExceptionAsync(context, e);
        }
    }

    public static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = GetStatusCode(exception);

        var response = new 
        {
            status = statusCode,
            details = exception.Message
        };

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    public static int GetStatusCode(Exception exception) => exception switch 
        {
            BadHttpRequestException => StatusCodes.Status400BadRequest,
            //NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };
        
}