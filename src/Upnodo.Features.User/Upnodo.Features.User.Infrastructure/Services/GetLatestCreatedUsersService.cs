using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.User.Application.GetLatestCreatedUsers;
using Upnodo.Features.User.Infrastructure.Mappers;
using Upnodo.Features.User.Infrastructure.Repositories;

namespace Upnodo.Features.User.Infrastructure.Services
{
    public class GetLatestCreatedUsersService : IService<GetLatestCreatedUsersResponse>
    {
        private readonly MongoDbUserRepository _mongoDbRepository;
        private readonly ILogger<GetLatestCreatedUsersService> _logger;

        public GetLatestCreatedUsersService(MongoDbUserRepository mongoDbRepository, ILogger<GetLatestCreatedUsersService> logger)
        {
            _mongoDbRepository = mongoDbRepository;
            _logger = logger;
        }

        public async Task<GetLatestCreatedUsersResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(GetLatestCreatedUsersService)} running.");

            if (request is not int totalNumberOfMoodRecords)
            {
                _logger.LogError(
                    $"{nameof(request)} is not of type {typeof(int)}");

                throw new ArgumentException(
                    $"{nameof(request)} is not of type {typeof(int)}");
            }

            var response = await _mongoDbRepository.ReadLatestAsync(totalNumberOfMoodRecords);

            return new GetLatestCreatedUsersResponse(true, UserMapper.GetModelCollection(response));
        }
    }
}
