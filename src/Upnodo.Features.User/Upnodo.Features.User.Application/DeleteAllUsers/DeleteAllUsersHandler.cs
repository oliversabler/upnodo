using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Upnodo.Features.User.Application.DeleteAllUsers
{
    public class DeleteAllUsersHandler
        : IRequestHandler<DeleteAllUsersCommand, DeleteAllUsersResponse>
    {

        private readonly ILogger<DeleteAllUsersHandler> _logger;

        public DeleteAllUsersHandler(ILogger<DeleteAllUsersHandler> logger)
        {
            _logger = logger;
        }

        public async Task<DeleteAllUsersResponse> Handle(
            DeleteAllUsersCommand request,
            CancellationToken cancellationToken)
        {
            _logger.LogTrace($"{nameof(DeleteAllUsersHandler)} running.");

            throw new System.NotImplementedException();
        }
    }
}
