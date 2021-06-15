using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.DeleteAllMoodRecords;

namespace Upnodo.Api.Features.Mood.Handlers
{
    public class DeleteAllMoodRecordsHandler : 
        IRequestHandler<DeleteAllMoodRecordsCommand, DeleteAllMoodRecordsResponse>
    {
        private readonly IService<DeleteAllMoodRecordsResponse> _deleteAllMoodRecordsService;
        private readonly ILogger<DeleteAllMoodRecordsHandler> _logger;

        public DeleteAllMoodRecordsHandler(
            IService<DeleteAllMoodRecordsResponse> deleteAllMoodRecordsService, 
            ILogger<DeleteAllMoodRecordsHandler> logger)
        {
            _deleteAllMoodRecordsService = deleteAllMoodRecordsService;
            _logger = logger;
        }

        public async Task<DeleteAllMoodRecordsResponse> Handle(
            DeleteAllMoodRecordsCommand request, 
            CancellationToken token)
        {
            _logger.LogTrace($"{nameof(DeleteAllMoodRecordsHandler)} running.");
            return await _deleteAllMoodRecordsService.RunAsync(request, token);
        }
    }
}