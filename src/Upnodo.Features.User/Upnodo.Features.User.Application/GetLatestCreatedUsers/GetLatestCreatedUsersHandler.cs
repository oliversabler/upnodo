using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Abstractions;

namespace Upnodo.Features.User.Application.GetLatestCreatedUsers
{
    public class GetLatestCreatedUsersHandler :
        IRequestHandler<GetLatestCreatedUsersQuery, GetLatestCreatedUsersResponse>
    {
        private readonly IService<GetLatestCreatedUsersResponse> _getLatestCreatedUsersService;
        private readonly ILogger<GetLatestCreatedUsersHandler> _logger;

        public GetLatestCreatedUsersHandler(
            IService<GetLatestCreatedUsersResponse> getLatestCreatedUsersService,
            ILogger<GetLatestCreatedUsersHandler> logger)
        {
            _getLatestCreatedUsersService = getLatestCreatedUsersService;
            _logger = logger;
        }

        public async Task<GetLatestCreatedUsersResponse> Handle(
            GetLatestCreatedUsersQuery request,
            CancellationToken token)
        {
            _logger.LogTrace($"{nameof(GetLatestCreatedUsersHandler)} running.");

            return await _getLatestCreatedUsersService.RunAsync(request.TotalNumberOfUsers, token);
        }
    }
}
