using System.Text.Json;
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

        public MoodRecord Create(MoodRecord moodRecord)
        {
            _logger.LogTrace($"{nameof(Create)} in {nameof(MoodRecordRepository)} running. Creating {nameof(moodRecord)} body: {JsonSerializer.Serialize(moodRecord)}");
            _moods.InsertOne(new MoodRecordCollection
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

        public void Delete(string moodRecordId)
        {
            _logger.LogTrace($"{nameof(Delete)} in {nameof(MoodRecordRepository)} running. Deleting {nameof(moodRecordId)}: {moodRecordId}");
            var deleteFilter = Builders<MoodRecordCollection>.Filter.Eq(Constants.Elements.MoodRecordId, moodRecordId);

            _moods.DeleteOne(deleteFilter);
        }

        public MoodRecord Read(string moodRecordId)
        {
            _logger.LogTrace($"{nameof(Read)} in {nameof(MoodRecordRepository)} running. Reading {nameof(moodRecordId)}: {moodRecordId}");

            var readFilter = Builders<MoodRecordCollection>.Filter.Eq(Constants.Elements.MoodRecordId, moodRecordId);
            var moodCollection = _moods.Find(readFilter).FirstOrDefault();

            return MoodRecord.CreateMood(
                moodCollection.MoodRecordId,
                moodCollection.DateCreated,
                moodCollection.DateUpdated,
                moodCollection.MoodStatus,
                moodCollection.User.UserId!,
                moodCollection.User.Username!,
                moodCollection.User.Email!);
        }

        public MoodRecord Update(MoodRecord moodRecord)
        {
            _logger.LogTrace($"{nameof(Update)} in {nameof(MoodRecordRepository)} running. Updating {nameof(moodRecord)} body: {JsonSerializer.Serialize(moodRecord)}");

            var filter =
                Builders<MoodRecordCollection>.Filter.Eq(Constants.Elements.MoodRecordId, moodRecord.MoodRecordId);
            var update = Builders<MoodRecordCollection>.Update
                .Set(Constants.Elements.DateUpdated, moodRecord.DateUpdated)
                .Set(Constants.Elements.Mood, moodRecord.MoodStatus);
            
            _moods.UpdateOneAsync(filter, update);

            // Not optimal, does not return the updated document at all times
            var readFilter =
                Builders<MoodRecordCollection>.Filter.Eq(Constants.Elements.MoodRecordId, moodRecord.MoodRecordId);
            var moodCollection = _moods.Find(readFilter).FirstOrDefault();
            
            return MoodRecord.UpdateMood(
                moodCollection.MoodRecordId,
                moodCollection.DateCreated,
                moodCollection.DateUpdated,
                moodCollection.MoodStatus);
        }
    }
}