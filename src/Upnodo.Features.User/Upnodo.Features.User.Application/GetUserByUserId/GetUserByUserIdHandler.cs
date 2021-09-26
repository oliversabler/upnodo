using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Abstractions;

namespace Upnodo.Features.User.Application.GetUserByUserId
{
    public class GetUserByUserIdHandler :
        IRequestHandler<GetUserByUserIdQuery, GetUserByUserIdResponse>
    {
        private readonly IService<GetUserByUserIdResponse> _getUserByUserIdService;
        private readonly ILogger<GetUserByUserIdHandler> _logger;

        public GetUserByUserIdHandler(
            IService<GetUserByUserIdResponse> getUserByUserIdService,
            ILogger<GetUserByUserIdHandler> logger)
        {
            _getUserByUserIdService = getUserByUserIdService;
            _logger = logger;
        }

        public async Task<GetUserByUserIdResponse> Handle(
            GetUserByUserIdQuery request,
            CancellationToken token)
        {
            _logger.LogTrace($"{nameof(GetUserByUserIdHandler)} running.");

            return await _getUserByUserIdService.RunAsync(request.MoodRecordId, token);
        }
    }
}
