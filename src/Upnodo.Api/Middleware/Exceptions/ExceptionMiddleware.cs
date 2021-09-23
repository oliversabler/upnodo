using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.CircuitBreaker;

#pragma warning disable HAA0301, HAA0302, HAA0303
namespace Upnodo.Api.Middleware.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly AsyncCircuitBreakerPolicy _policy;
        
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;

            _policy = Policy
                .Handle<Exception>()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                if (_policy.CircuitState == CircuitState.Open)
                {
                    throw new ServiceUnavailableException("Service is unavailable.");
                }

                await _policy.ExecuteAsync(async () =>
                {
                    await _next(httpContext);
                });
            }
            catch (TaskCanceledException ex)
            {
                _logger.LogInformation(ex, ex.Message);
                await HandleGlobalExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleGlobalExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleGlobalExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            return
                httpContext.Response.WriteAsync(
                    new GlobalExceptionDetails(
                            httpContext.Response.StatusCode,
                            exception.Message)
                        .ToString());
        }
    }
}
#pragma warning restore HAA0301, HAA0302, HAA0303
