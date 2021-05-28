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

        public MoodRecord Create(MoodRecord moodRecord)
        {
            _moods.InsertOne(moodRecord);

            return moodRecord;
        }

        public void Delete(string moodRecordId)
        {
            var deleteFilter = Builders<MoodRecord>.Filter.Eq(Constants.Elements.MoodRecordId, moodRecordId);

            _moods.DeleteOne(deleteFilter);
        }

        public MoodRecord Read(string moodRecordId)
        {
            var readFilter = Builders<MoodRecord>.Filter.Eq(Constants.Elements.MoodRecordId, moodRecordId);

            return _moods.Find(readFilter).FirstOrDefault();
        }

        public MoodRecord Update(MoodRecord moodRecord)
        {
            var filter = Builders<MoodRecord>.Filter.Eq(Constants.Elements.MoodRecordId, moodRecord.MoodRecordId);
            var update = Builders<MoodRecord>.Update
                .Set(Constants.Elements.DateUpdated, moodRecord.DateUpdated)
                .Set(Constants.Elements.Mood, moodRecord.Mood);

            _moods.UpdateOneAsync(filter, update);

            var readFilter = Builders<MoodRecord>.Filter.Eq(Constants.Elements.MoodRecordId, moodRecord.MoodRecordId);

            return _moods.Find(readFilter).FirstOrDefault();
        }
    }
}