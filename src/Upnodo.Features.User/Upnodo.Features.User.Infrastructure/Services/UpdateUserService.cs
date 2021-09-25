using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.User.Application.UpdateUser;
using Upnodo.Features.User.Infrastructure.Mappers;
using Upnodo.Features.User.Infrastructure.Repositories;

namespace Upnodo.Features.User.Infrastructure.Services
{
    public class UpdateUserService : IService<UpdateUserResponse>
    {
        private readonly MongoDbUserRepository _userRepository;
        private readonly ILogger<UpdateUserService> _logger;

        public UpdateUserService(
            MongoDbUserRepository userRepository,
            ILogger<UpdateUserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<UpdateUserResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(UpdateUserService)} running.");

            if (request is not Domain.User user)
            {
                _logger.LogError(
                    $"{nameof(request)} with body: {JsonSerializer.Serialize(request)} " +
                    $"is not of type {typeof(Domain.User)}");

                throw new ArgumentException($"{nameof(request)} is not of type {typeof(Domain.User)}");
            }

            var response = await _userRepository.UpdateAsync(UserMapper.GetDto(user));

            return new UpdateUserResponse(true, response);
        }
    }
}