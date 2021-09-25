using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;

namespace Upnodo.Features.User.Application.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        private readonly IService<DeleteUserResponse> _deleteUserService;
        private readonly ILogger<DeleteUserHandler> _logger;

        public DeleteUserHandler(
            IService<DeleteUserResponse> deleteUserService,
            ILogger<DeleteUserHandler> logger)
        {
            _deleteUserService = deleteUserService;
            _logger = logger;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserCommand command, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(DeleteUserHandler)} running.");

            return await _deleteUserService.RunAsync(command.UserId, token);
        }
    }
}