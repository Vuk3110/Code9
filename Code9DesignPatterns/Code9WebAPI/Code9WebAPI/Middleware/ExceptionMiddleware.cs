using System.Net;
using System.Text.Json;
using Code9.Domain.Exceptions;

namespace Code9WebAPI.Middleware;

public sealed class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context, ILogger<ExceptionMiddleware> logger)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unhandled exception has occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }
    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
            var response = context.Response;
            response.ContentType = "application/json";

            string jsonApiResponse;

            switch (ex)
            {
                case CinemaNotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    jsonApiResponse = JsonSerializer.Serialize(new
                    {
                        Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/404",
                        Title = "Not found error.",
                        Status = 404,
                        Detail = ex.Message,
                        Instance = $"{context.Request.Path}"
                    });
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    jsonApiResponse = JsonSerializer.Serialize(new
                    {
                        Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500",
                        Title = "Internal server error.",
                        Status = 500,
                        Detail = ex.Message,
                        Instance = $"{context.Request.Path}"
                    });

                    response.ContentLength = jsonApiResponse.Length;

                    break;
            }

            await response.WriteAsync(jsonApiResponse);
        }
}