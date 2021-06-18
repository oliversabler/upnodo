using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.Mood.Application.GetLatestCreatedMoodRecords;
using Upnodo.Features.Mood.Domain;
using Upnodo.Features.Mood.Infrastructure.Repositories;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class GetLatestCreatedMoodRecordsService : IService<GetLatestCreatedMoodRecordsResponse>
    {
        private readonly MongoDbRepository _mongoDbRepository;
        private readonly ILogger<GetMoodRecordByMoodRecordIdService> _logger;

        public GetLatestCreatedMoodRecordsService(
            MongoDbRepository mongoDbRepository,
            ILogger<GetMoodRecordByMoodRecordIdService> logger)
        {
            _mongoDbRepository = mongoDbRepository;
            _logger = logger;
        }

        public async Task<GetLatestCreatedMoodRecordsResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(GetLatestCreatedMoodRecordsService)} running.");

            if (request is not int totalNumberOfMoodRecords)
            {
                _logger.LogError(
                    $"{nameof(request)} is not of type {typeof(int)}");

                throw new ArgumentException(
                    $"{nameof(request)} is not of type {typeof(int)}");
            }

            var records = await _mongoDbRepository.ReadLatestAsync(totalNumberOfMoodRecords);

            var moodRecords = new List<MoodRecord>();

            foreach (var moodRecord in moodRecords)
            {
                moodRecords.Add(
                    MoodRecord.CreateMood(
                        moodRecord.MoodRecordId,
                        moodRecord.DateCreated,
                        moodRecord.DateUpdated,
                        moodRecord.MoodStatus,
                        moodRecord.User?.UserId!,
                        moodRecord.User?.Username!,
                        moodRecord.User?.Email!,
                        moodRecord.User?.Firstname!,
                        moodRecord.User?.Lastname!));
            }

            return new GetLatestCreatedMoodRecordsResponse(true, records);
        }
    }
}