using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Upnodo.Features.Mood.Domain
{
    public class MoodRecord
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        [BsonElement(Constants.Elements.DateCreated)]
        public DateTime DateCreated { get; private init; }

        [BsonElement(Constants.Elements.DateUpdated)]
        public DateTime DateUpdated { get; private init; }

        [BsonElement(Constants.Elements.Mood)]
        public MoodStatus MoodStatus { get; private init; }
        
        [BsonElement(Constants.Elements.MoodRecordId)]
        public string MoodRecordId { get; private init; } = default!;

        [BsonElement(Constants.Elements.UserId)]
        public User User { get; init; } = default!;

        public static MoodRecord CreateMood(
            DateTime dateCreated,
            MoodStatus moodStatus,
            string moodRecordId,
            string userId,
            string username,
            string email)
        {
            return new()
            {
                DateCreated = dateCreated,
                MoodStatus = moodStatus,
                MoodRecordId = moodRecordId,
                User = CreateUser(userId, username, email)
            };
        }

        public static MoodRecord UpdateMood(
            DateTime dateUpdated,
            MoodStatus moodStatus,
            string moodRecordId)
        {
            return new()
            {
                DateUpdated = dateUpdated,
                MoodStatus = moodStatus,
                MoodRecordId = moodRecordId
            };
        }

        private static User CreateUser(string userId, string username, string email)
        {
            return new()
            {
                UserId = userId,
                Username = username,
                Email = email
            };
        }
    }
}