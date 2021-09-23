using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.Mood.Infrastructure.Dtos;

namespace Upnodo.Features.Mood.Infrastructure.Repositories
{
    public class MongoDbMoodRecordRepository
    {
        private readonly IMongoCollection<MoodRecordDto> _moods;
        private readonly ILogger<MongoDbMoodRecordRepository> _logger;

        public MongoDbMoodRecordRepository(
            IMongoDbSettings settings,
            ILogger<MongoDbMoodRecordRepository> logger)
        {
            _logger = logger;
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);

            _moods = db.GetCollection<MoodRecordDto>(settings.MoodsCollectionName);
        }

        public async Task<string> CreateAsync(MoodRecordDto moodRecord)
        {
            _logger.LogTrace(
                $"{nameof(CreateAsync)} in {nameof(MongoDbMoodRecordRepository)} running. " +
                $"Creating {nameof(moodRecord)} body: {JsonSerializer.Serialize(moodRecord)}");

            await _moods.InsertOneAsync(moodRecord);

            return moodRecord.MoodRecordId;
        }

        public async Task DeleteAllAsync()
        {
            _logger.LogTrace($"{nameof(DeleteAllAsync)} in {nameof(MongoDbMoodRecordRepository)}. Deleting all mood records");
            await _moods.DeleteManyAsync(_ => true);
        }

        public async Task DeleteAsync(string moodRecordId)
        {
            _logger.LogTrace(
                $"{nameof(DeleteAsync)} in {nameof(MongoDbMoodRecordRepository)}. " +
                $"Deleting {nameof(moodRecordId)}: {moodRecordId}");

            var deleteFilter = Builders<MoodRecordDto>.Filter.Eq(Constants.Elements.MoodRecordId, moodRecordId);

            await _moods.DeleteOneAsync(deleteFilter);
        }

        public async Task<List<MoodRecordDto>> ReadLatestAsync(int numberOfMoodRecords)
        {
            _logger.LogTrace(
                $"{nameof(ReadAsync)} in {nameof(MongoDbMoodRecordRepository)}. " +
                $"Reading {nameof(numberOfMoodRecords)}: {numberOfMoodRecords.ToString()}");

            var result = await _moods.Find(_ => true)
                .SortByDescending(f => f.DateCreated)
                .Limit(numberOfMoodRecords)
                .ToListAsync();

            return result;
        }

        public async Task<MoodRecordDto> ReadAsync(string moodRecordId)
        {
            _logger.LogTrace(
                $"{nameof(ReadAsync)} in {nameof(MongoDbMoodRecordRepository)}. " +
                $"Reading {nameof(moodRecordId)}: {moodRecordId}");

            var result = await _moods.FindAsync(filter => filter.MoodRecordId == moodRecordId);
            var moodRecord = result.FirstOrDefault();

            return moodRecord;
        }

        public async Task<string> UpdateAsync(MoodRecordDto moodRecord)
        {
            _logger.LogTrace(
                $"{nameof(UpdateAsync)} in {nameof(MongoDbMoodRecordRepository)}. " +
                $"Updating {nameof(moodRecord)} body: {JsonSerializer.Serialize(moodRecord)}");

            var filter = Builders<MoodRecordDto>.Filter.Eq(
                nameof(MoodRecordDto.MoodRecordId),
                moodRecord.MoodRecordId);

            var update = Builders<MoodRecordDto>.Update
                .Set(nameof(MoodRecordDto.DateUpdated), moodRecord.DateUpdated)
                .Set(nameof(MoodRecordDto.MoodStatus), moodRecord.MoodStatus);

            await _moods.UpdateOneAsync(filter, update);

            return moodRecord.MoodRecordId;
        }
    }
}