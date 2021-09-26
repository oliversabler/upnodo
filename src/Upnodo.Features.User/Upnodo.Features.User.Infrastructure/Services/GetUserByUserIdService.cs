using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.User.Application.GetUserByUserId;
using Upnodo.Features.User.Infrastructure.Mappers;
using Upnodo.Features.User.Infrastructure.Repositories;

namespace Upnodo.Features.User.Infrastructure.Services
{
    public class GetUserByUserIdService : IService<GetUserByUserIdResponse>
    {
        private readonly MongoDbUserRepository _mongoDbRepository;
        private readonly ILogger<GetUserByUserIdService> _logger;

        public GetUserByUserIdService(
            MongoDbUserRepository mongoDbRepository,
            ILogger<GetUserByUserIdService> logger)
        {
            _mongoDbRepository = mongoDbRepository;
            _logger = logger;
        }

        public async Task<GetUserByUserIdResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(GetUserByUserIdService)} running.");

            if (request is not string userId)
            {
                _logger.LogError(
                    $"{nameof(request)} with body: {JsonSerializer.Serialize(request)} " +
                    $"is not of type {typeof(GetUserByUserIdQuery)}");

                throw new ArgumentException(
                    $"{nameof(request)} is not of type {typeof(GetUserByUserIdQuery)}");
            }

            var response = await _mongoDbRepository.ReadAsync(userId);

            return new GetUserByUserIdResponse(true, UserMapper.GetModel(response));
        }
    }
}
