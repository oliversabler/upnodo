using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.User.Application.CreateUser;
using Upnodo.Features.User.Application.DeleteUser;
using Upnodo.Features.User.Infrastructure.Repositories;

namespace Upnodo.Features.User.Infrastructure.Services
{
    public class DeleteUserService : IService<DeleteUserResponse>
    {
        private readonly MongoDbUserRepository _userRepository;
        private readonly ILogger<DeleteUserService> _logger;

        public DeleteUserService(
            MongoDbUserRepository userRepository, 
            ILogger<DeleteUserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<DeleteUserResponse> RunAsync<T>(T userId, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(CreateUserService)} running.");

            if (userId is not string)
            {
                _logger.LogError(
                    $"{nameof(userId)} with id: {userId} " +
                    $"is not of type {typeof(string)}");

                throw new ArgumentException($"{nameof(userId)} is not of type {typeof(string)}");
            }

            await _userRepository.DeleteAsync(userId.ToString());

            return new DeleteUserResponse(true, null);
        }
    }
}