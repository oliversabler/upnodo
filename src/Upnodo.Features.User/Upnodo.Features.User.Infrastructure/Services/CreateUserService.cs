using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.User.Application.CreateUser;
using Upnodo.Features.User.Infrastructure.Mappers;

namespace Upnodo.Features.User.Infrastructure.Services
{
    public class CreateUserService : IService<CreateUserResponse>
    {
        private readonly MongoDbUserRepository _userRepository;
        private readonly ILogger<CreateUserService> _logger;

        public CreateUserService(
            MongoDbUserRepository userRepository,
            ILogger<CreateUserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<CreateUserResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(CreateUserService)} running.");

            if (request is not Domain.User user)
            {
                _logger.LogError(
                    $"{nameof(request)} with body: {JsonSerializer.Serialize(request)} " +
                    $"is not of type {typeof(Domain.User)}");

                throw new ArgumentException($"{nameof(request)} is not of type {typeof(Domain.User)}");
            }

            var response = await _userRepository.CreateAsync(UserMapper.GetDto(user));

            return new CreateUserResponse(true, response);
        }
    }
}