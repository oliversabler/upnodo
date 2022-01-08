using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;

namespace Upnodo.Api.PipelineBehaviors
{
    public class CacheBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ICacheableQuery
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<CacheBehavior<TRequest, TResponse>> _logger;

        private const int AbsoluteExpiration = 15;
        private const int SlidingExpiration = 3;

        public CacheBehavior(IDistributedCache cache, ILogger<CacheBehavior<TRequest, TResponse>> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken token,
            RequestHandlerDelegate<TResponse> next)
        {
            if (request?.Cache == null)
            {
                return await next();
            }

            TResponse response;

            if (request.Cache.BypassCache)
                return await next();

            var cachedResponse = await _cache.GetAsync(request.Cache.CacheKey, token);
            if (cachedResponse != null)
            {
                response = JsonSerializer.Deserialize<TResponse>(Encoding.Default.GetString(cachedResponse))!;
                _logger.LogInformation($"Fetched from Cache: {request.Cache.CacheKey}.");
            }
            else
            {
                response = await GetResponseAndAddToCache(request, token, next);
                _logger.LogInformation($"Added to cache: {request.Cache.CacheKey}.");
            }

            return response;
        }

        private async Task<TResponse> GetResponseAndAddToCache(
            TRequest request,
            CancellationToken token,
            RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(AbsoluteExpiration),
                SlidingExpiration = TimeSpan.FromMinutes(SlidingExpiration),

            };

            var serializedData = Encoding.Default.GetBytes(JsonSerializer.Serialize(response));

            await _cache.SetAsync(request.Cache!.CacheKey, serializedData, options, token);

            return response;
        }
    }
}