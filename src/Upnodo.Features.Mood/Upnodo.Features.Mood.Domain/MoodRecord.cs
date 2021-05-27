using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Upnodo.Features.Mood.Domain
{
    public class MoodRecord
    {
        [BsonElement("dateCreated")]
        public DateTime DateCreated { get; private init; }

        [BsonElement("dateUpdated")]
        public DateTime DateUpdated { get; private init; }

        [BsonElement("mood")]
        public Mood Mood { get; private init; }

        [BsonElement("moodRecordId")]
        public string MoodRecordId { get; private init; } = default!;

        [BsonElement("userId")]
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