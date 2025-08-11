using ECommerce.Domain.Exceptions;

namespace ECommerce.Api.Middlewares;

/// <summary>
/// Global exception middleware to handle unhandled exceptions in the API pipeline.
/// </summary>
public class ExceptionMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;

    /// <summary>
    /// Constructs a new instance.
    /// </summary>
    /// <param name="logger">Logger.</param>
    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Invokes the middleware.
    /// </summary>
    /// <param name="context">Http context.</param>
    /// <param name="next">Next middleware.</param>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException notFound)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync(notFound.Message);

            _logger.LogWarning(notFound, "{Message}", notFound.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An unhandled exception occurred: {Message}", e.Message);

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Something went wrong...");
        }
    }
}
