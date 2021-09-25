using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;

namespace Upnodo.Features.User.Application.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IService<UpdateUserResponse> _updateUserService;
        private readonly ILogger<UpdateUserHandler> _logger;

        public UpdateUserHandler(
            IService<UpdateUserResponse> updateUserService,
            ILogger<UpdateUserHandler> logger)
        {
            _updateUserService = updateUserService;
            _logger = logger;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserCommand command, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(UpdateUserResponse)} running.");

            var user = Domain.User.CreateUser(
                command.UserId,
                command.Username,
                command.Email,
                command.Firstname,
                command.Lastname);

            return await _updateUserService.RunAsync(user, token);
        }
    }
}