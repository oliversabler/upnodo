using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;

namespace Upnodo.Features.User.Application.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IService<CreateUserResponse> _createUserService;
        private readonly ILogger<CreateUserHandler> _logger;

        public CreateUserHandler(
            IService<CreateUserResponse> createUserService,
            ILogger<CreateUserHandler> logger)
        {
            _createUserService = createUserService;
            _logger = logger;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand command, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(CreateUserHandler)} running.");

            var user = Domain.User.CreateUser(
                command.UserId,
                command.Username,
                command.Email,
                command.Firstname,
                command.Lastname);

            return await _createUserService.RunAsync(user, token);
        }
    }
}