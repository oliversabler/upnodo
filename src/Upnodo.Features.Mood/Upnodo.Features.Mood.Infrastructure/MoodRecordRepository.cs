using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Upnodo.BuildingBlocks.Application.Configurations;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Infrastructure
{
    public class MoodRecordRepository
    {
        private readonly IMongoCollection<MoodRecord> _moods;

        public MoodRecordRepository(IUpnodoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);
            
            _moods = db.GetCollection<MoodRecord>(settings.MoodsCollectionName);
        }

        public MoodRecord Alter(MoodRecord moodRecord)
        {
            var filter = Builders<MoodRecord>.Filter.Eq("moodRecordId", moodRecord.MoodRecordId);
            var update = Builders<MoodRecord>.Update
                .Set("dateUpdated", moodRecord.DateUpdated)
                .Set("mood", moodRecord.Mood);
            
            _moods.UpdateOne(filter, update);

            return moodRecord;
        }
        
        public MoodRecord Create(MoodRecord moodRecord)
        {
            // Todo: Check if user exists
            _moods.InsertOne(moodRecord);

            return moodRecord;
        }

        public void Delete(string moodRecordId)
        {
            var deleteFilter = Builders<MoodRecord>.Filter.Eq("moodRecordId", moodRecordId);
            
            _moods.DeleteOne(deleteFilter);
        }

        public List<MoodRecord> Read(string userId)
        {
            throw new NotImplementedException();
        }
    }
}