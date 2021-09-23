using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.Mood.Application.DeleteAllMoodRecords;
using Upnodo.Features.Mood.Infrastructure.Repositories;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class DeleteAllMoodRecordsService : IService<DeleteAllMoodRecordsResponse>
    {
        private readonly MongoDbMoodRecordRepository _mongoDbRepository;
        private readonly ILogger<DeleteMoodRecordService> _logger;

        public DeleteAllMoodRecordsService(
            MongoDbMoodRecordRepository mongoDbRepository,
            ILogger<DeleteMoodRecordService> logger)
        {
            _mongoDbRepository = mongoDbRepository;
            _logger = logger;
        }

        public async Task<DeleteAllMoodRecordsResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(DeleteAllMoodRecordsService)} running.");

            await _mongoDbRepository.DeleteAllAsync();

            return new DeleteAllMoodRecordsResponse(true);
        }
    }
}