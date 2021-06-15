using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Api.PipelineBehaviors
{
    public class CacheBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheableQuery
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<CacheBehavior<TRequest, TResponse>> _logger;
        
        private const int AbsoluteExpiration = 15;

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
            TResponse response;
            
            if (request.BypassCache) 
                return await next();
            
            async Task<TResponse> GetResponseAndAddToCache()
            {
                response = await next();
                var slidingExpiration = TimeSpan.FromMinutes(AbsoluteExpiration);
                
                var options = new DistributedCacheEntryOptions
                {
                    SlidingExpiration = slidingExpiration
                };
                
                var serializedData = Encoding.Default.GetBytes(JsonSerializer.Serialize(response));
                
                await _cache.SetAsync(request.CacheKey, serializedData, options, token);
                
                return response;
            }
            
            var cachedResponse = await _cache.GetAsync(request.CacheKey, token);
            if (cachedResponse != null)
            {
                response = JsonSerializer.Deserialize<TResponse>(Encoding.Default.GetString(cachedResponse))!;
                _logger.LogInformation($"Fetched from Cache: {request.CacheKey}.");
            }
            else
            {
                response = await GetResponseAndAddToCache();
                _logger.LogInformation($"Added to cache: {request.CacheKey}.");
            }
            
            return response!;
        }
    }
}