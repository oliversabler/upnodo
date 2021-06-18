using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.Mood.Domain;
using Upnodo.Features.Mood.Domain.DTO;

namespace Upnodo.Features.Mood.Infrastructure.Repositories
{
    public class MongoDbRepository
    {
        private readonly IMongoCollection<MoodRecordDto> _moods;
        private readonly ILogger<MongoDbRepository> _logger;

        public MongoDbRepository(
            IMongoDbSettings settings,
            ILogger<MongoDbRepository> logger)
        {
            _logger = logger;
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);

            _moods = db.GetCollection<MoodRecordDto>(settings.MoodsCollectionName);
        }

        public async Task<string> CreateAsync(MoodRecordDto moodRecord)
        {
            _logger.LogTrace(
                $"{nameof(CreateAsync)} in {nameof(MongoDbRepository)} running. " +
                $"Creating {nameof(moodRecord)} body: {JsonSerializer.Serialize(moodRecord)}");

            await _moods.InsertOneAsync(moodRecord);

            return moodRecord.MoodRecordId;
        }

        public async Task DeleteAsync(string moodRecordId)
        {
            _logger.LogTrace(
                $"{nameof(DeleteAsync)} in {nameof(MongoDbRepository)}. " +
                $"Deleting {nameof(moodRecordId)}: {moodRecordId}");

            var deleteFilter = Builders<MoodRecordDto>.Filter.Eq(Constants.Elements.MoodRecordId, moodRecordId);

            await _moods.DeleteOneAsync(deleteFilter);
        }

        public async Task DeleteAllAsync()
        {
            _logger.LogTrace($"{nameof(DeleteAllAsync)} in {nameof(MongoDbRepository)}. Deleting all mood records");
            await _moods.DeleteManyAsync(_ => true);
        }

        public async Task<MoodRecord> ReadAsync(string moodRecordId)
        {
            _logger.LogTrace(
                $"{nameof(ReadAsync)} in {nameof(MongoDbRepository)}. " +
                $"Reading {nameof(moodRecordId)}: {moodRecordId}");

            var readFilter = Builders<MoodRecordDto>.Filter.Eq(Constants.Elements.MoodRecordId, moodRecordId);
            var result = await _moods.FindAsync(readFilter);
            var moodRecordCollection = result.FirstOrDefault();

            // Todo: Pass DTO
            return MoodRecord.CreateMood(
                moodRecordCollection.MoodRecordId,
                moodRecordCollection.DateCreated,
                moodRecordCollection.DateUpdated,
                moodRecordCollection.MoodStatus,
                moodRecordCollection.User.UserId!,
                moodRecordCollection.User.Username!,
                moodRecordCollection.User.Email!,
                moodRecordCollection.User.Firstname,
                moodRecordCollection.User.Lastname);
        }

        public async Task<List<MoodRecord>> ReadLatestAsync(int numberOfMoodRecords)
        {
            _logger.LogTrace(
                $"{nameof(ReadAsync)} in {nameof(MongoDbRepository)}. " +
                $"Reading {nameof(numberOfMoodRecords)}: {numberOfMoodRecords.ToString()}");

            var result = await _moods.Find(_ => true)
                .SortByDescending(f => f.DateCreated)
                .Limit(numberOfMoodRecords)
                .ToListAsync();

            // Map Dto => Model

            return result.Select(moodRecordCollection =>
                    MoodRecord.CreateMood(
                        moodRecordCollection.MoodRecordId,
                        moodRecordCollection.DateCreated,
                        moodRecordCollection.DateUpdated,
                        moodRecordCollection.MoodStatus,
                        moodRecordCollection.User.UserId!,
                        moodRecordCollection.User.Username!,
                        moodRecordCollection.User.Email!,
                        moodRecordCollection.User.Firstname,
                        moodRecordCollection.User.Lastname))
                .ToList();
        }

        public async Task<MoodRecord> UpdateAsync(MoodRecord moodRecord)
        {
            _logger.LogTrace(
                $"{nameof(UpdateAsync)} in {nameof(MongoDbRepository)}. " +
                $"Updating {nameof(moodRecord)} body: {JsonSerializer.Serialize(moodRecord)}");

            var filter = Builders<MoodRecordDto>.Filter.Eq(
                Constants.Elements.MoodRecordId,
                moodRecord.MoodRecordId);

            var update = Builders<MoodRecordDto>.Update
                .Set(Constants.Elements.DateUpdated, moodRecord.DateUpdated)
                .Set(Constants.Elements.Mood, moodRecord.MoodStatus);

            await _moods.UpdateOneAsync(filter, update);

            // Not optimal, does not return the updated document at all times
            _logger.LogTrace($"Fetching updated {nameof(moodRecord)}");

            var readFilter = Builders<MoodRecordDto>.Filter.Eq(
                Constants.Elements.MoodRecordId,
                moodRecord.MoodRecordId);
            var moodCollection = _moods.Find(readFilter).FirstOrDefault();

            var updatedMoodRecord = MoodRecord.UpdateMood(
                moodCollection.MoodRecordId,
                moodCollection.DateCreated,
                moodCollection.DateUpdated,
                moodCollection.MoodStatus);

            _logger.LogTrace(
                $"Fetched updated {nameof(moodRecord)}. Body: {JsonSerializer.Serialize(updatedMoodRecord)}");

            return updatedMoodRecord;
        }
    }
}