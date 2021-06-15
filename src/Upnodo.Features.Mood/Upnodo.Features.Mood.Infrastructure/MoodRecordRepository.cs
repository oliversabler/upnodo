using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Upnodo.BuildingBlocks.Application.Configurations;
using Upnodo.Features.Mood.Domain;
using Upnodo.Features.Mood.Infrastructure.Collections;

namespace Upnodo.Features.Mood.Infrastructure
{
    public class MoodRecordRepository
    {
        private readonly IMongoCollection<MoodRecordCollection> _moods;
        private readonly ILogger<MoodRecordRepository> _logger;

        public MoodRecordRepository(
            IUpnodoDatabaseSettings settings, 
            ILogger<MoodRecordRepository> logger)
        {
            _logger = logger;
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);

            _moods = db.GetCollection<MoodRecordCollection>(settings.MoodsCollectionName);
        }

        public async Task<MoodRecord> CreateAsync(MoodRecord moodRecord)
        {
            _logger.LogTrace($"{nameof(CreateAsync)} in {nameof(MoodRecordRepository)} running. Creating {nameof(moodRecord)} body: {JsonSerializer.Serialize(moodRecord)}");
            await _moods.InsertOneAsync(new MoodRecordCollection
            {
                MoodRecordId = moodRecord.MoodRecordId,
                DateCreated = moodRecord.DateCreated,
                MoodStatus = moodRecord.MoodStatus,
                User = new MoodRecordUserCollection
                {
                    UserId = moodRecord.User!.UserId!,
                    Username = moodRecord.User!.Username!,
                    Email = moodRecord.User!.Email!
                }
            });

            return moodRecord;
        }

        public async Task DeleteAsync(string moodRecordId)
        {
            _logger.LogTrace($"{nameof(DeleteAsync)} in {nameof(MoodRecordRepository)}. Deleting {nameof(moodRecordId)}: {moodRecordId}");
            var deleteFilter = Builders<MoodRecordCollection>.Filter.Eq(Constants.Elements.MoodRecordId, moodRecordId);

            await _moods.DeleteOneAsync(deleteFilter);
        }
        
        public async Task DeleteAllAsync()
        {
            _logger.LogTrace($"{nameof(DeleteAllAsync)} in {nameof(MoodRecordRepository)}. Deleting all mood records");
            await _moods.DeleteManyAsync(_ => true);
        }

        public async Task<MoodRecord> ReadAsync(string moodRecordId)
        {
            _logger.LogTrace($"{nameof(ReadAsync)} in {nameof(MoodRecordRepository)}. Reading {nameof(moodRecordId)}: {moodRecordId}");

            var readFilter = Builders<MoodRecordCollection>.Filter.Eq(Constants.Elements.MoodRecordId, moodRecordId);
            var result = await _moods.FindAsync(readFilter);
            var moodCollection = result.FirstOrDefault();

            return MoodRecord.CreateMood(
                moodCollection.MoodRecordId,
                moodCollection.DateCreated,
                moodCollection.DateUpdated,
                moodCollection.MoodStatus,
                moodCollection.User.UserId!,
                moodCollection.User.Username!,
                moodCollection.User.Email!);
        }

        public async Task<MoodRecord> UpdateAsync(MoodRecord moodRecord)
        {
            _logger.LogTrace($"{nameof(UpdateAsync)} in {nameof(MoodRecordRepository)}. Updating {nameof(moodRecord)} body: {JsonSerializer.Serialize(moodRecord)}");

            var filter = Builders<MoodRecordCollection>.Filter.Eq(
                Constants.Elements.MoodRecordId, 
                moodRecord.MoodRecordId);
            
            var update = Builders<MoodRecordCollection>.Update
                .Set(Constants.Elements.DateUpdated, moodRecord.DateUpdated)
                .Set(Constants.Elements.Mood, moodRecord.MoodStatus);
            
            await _moods.UpdateOneAsync(filter, update);

            // Not optimal, does not return the updated document at all times
            _logger.LogTrace($"Fetching updated {nameof(moodRecord)}");
            var readFilter = Builders<MoodRecordCollection>.Filter.Eq(
                Constants.Elements.MoodRecordId, 
                moodRecord.MoodRecordId);
            var moodCollection = _moods.Find(readFilter).FirstOrDefault();
            
            var updatedMoodRecord = MoodRecord.UpdateMood(
                moodCollection.MoodRecordId,
                moodCollection.DateCreated,
                moodCollection.DateUpdated,
                moodCollection.MoodStatus);
            
            _logger.LogTrace($"Fetched updated {nameof(moodRecord)}. Body: {JsonSerializer.Serialize(updatedMoodRecord)}");
            
            return updatedMoodRecord;
        }
    }
}