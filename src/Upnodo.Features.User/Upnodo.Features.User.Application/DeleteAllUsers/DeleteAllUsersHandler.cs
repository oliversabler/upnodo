using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Abstractions;

namespace Upnodo.Features.User.Application.DeleteAllUsers
{
    public class DeleteAllUsersHandler
        : IRequestHandler<DeleteAllUsersCommand, DeleteAllUsersResponse>
    {
        private readonly IService<DeleteAllUsersResponse> _deleteAllUsersService;
        private readonly ILogger<DeleteAllUsersHandler> _logger;

        public DeleteAllUsersHandler(
            IService<DeleteAllUsersResponse> deleteAllUsersService,
            ILogger<DeleteAllUsersHandler> logger)
        {
            _deleteAllUsersService = deleteAllUsersService;
            _logger = logger;
        }

        public async Task<DeleteAllUsersResponse> Handle(
            DeleteAllUsersCommand request,
            CancellationToken token)
        {
            _logger.LogTrace($"{nameof(DeleteAllUsersHandler)} running.");

            return await _deleteAllUsersService.RunAsync(request, token);
        }
    }
}
