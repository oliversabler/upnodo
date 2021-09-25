using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.User.Infrastructure.Repositories;

namespace Upnodo.Features.User.Infrastructure.Services
{
    public class DeleteAllUsersService : IService<DeleteAllUsersResponse>
    {
        private readonly MongoDbUserRepository _userRepository;
        private readonly ILogger<DeleteAllUsersService> _logger;

        public DeleteAllUsersService(
            MongoDbUserRepository userRepository,
            ILogger<DeleteAllUsersService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<DeleteAllUsersResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(DeleteAllUsersService)} running.");

            await _userRepository.DeleteAllAsync();

            return new DeleteAllUsersResponse(true);
        }
    }
}
