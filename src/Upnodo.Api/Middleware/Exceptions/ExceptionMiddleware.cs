using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.CircuitBreaker;
using Upnodo.BuildingBlocks.Application.Exceptions;

namespace Upnodo.Api.Middleware.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        
        private static readonly AsyncCircuitBreakerPolicy CircuitBreakerPolicy =
            Policy
                .Handle<Exception>()
                .AdvancedCircuitBreakerAsync(
                    0.5, 
                    TimeSpan.FromSeconds(10),
                    10,
                    TimeSpan.FromSeconds(30));

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                if (CircuitBreakerPolicy.CircuitState == CircuitState.Open)
                {
                    throw new ServiceUnavailableException("Service is unavailable.");
                }

                await CircuitBreakerPolicy.ExecuteAsync(() => _next(httpContext));
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

            return httpContext.Response.WriteAsync(
                new GlobalExceptionDetails(
                        httpContext.Response.StatusCode,
                        exception.Message)
                    .ToString());
        }
    }
}