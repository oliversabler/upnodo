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
        public Mood Mood { get; private init; }
        
        [BsonElement(Constants.Elements.MoodRecordId)]
        public string MoodRecordId { get; private init; } = default!;

        [BsonElement(Constants.Elements.UserId)]
        public string UserId { get; init; } = default!;

        public static MoodRecord CreateMood(
            DateTime dateCreated,
            Mood mood,
            string moodRecordId,
            string userId)
        {
            return new()
            {
                DateCreated = dateCreated,
                Mood = mood,
                MoodRecordId = moodRecordId,
                UserId = userId
            };
        }

        public static MoodRecord UpdateMood(
            DateTime dateUpdated,
            Mood mood,
            string moodRecordId)
        {
            return new()
            {
                DateUpdated = dateUpdated,
                Mood = mood,
                MoodRecordId = moodRecordId
            };
        }
    }
}