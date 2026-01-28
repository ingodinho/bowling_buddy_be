using System.Text.Json;

namespace Bowling.Buddy.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var problemDetails = new
            {
                title = "An error occurred while processing the request.",
                detail = ex.Message,
                statusCode = StatusCodes.Status500InternalServerError,
                exception = ex
            };

            string json = JsonSerializer.Serialize(problemDetails);
            await httpContext.Response.WriteAsync(json);
        }
    }
}