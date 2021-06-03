using MongoDB.Driver;
using Upnodo.BuildingBlocks.Application.Configurations;
using Upnodo.Features.Mood.Domain;
using Upnodo.Features.Mood.Infrastructure.Collections;

namespace Upnodo.Features.Mood.Infrastructure
{
    public class MoodRecordRepository
    {
        private readonly IMongoCollection<MoodRecordCollection> _moods;

        public MoodRecordRepository(IUpnodoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);

            _moods = db.GetCollection<MoodRecordCollection>(settings.MoodsCollectionName);
        }

        public MoodRecord Create(MoodRecord moodRecord)
        {
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
            var deleteFilter = Builders<MoodRecordCollection>.Filter.Eq(Constants.Elements.MoodRecordId, moodRecordId);

            _moods.DeleteOne(deleteFilter);
        }

        public MoodRecord Read(string moodRecordId)
        {
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