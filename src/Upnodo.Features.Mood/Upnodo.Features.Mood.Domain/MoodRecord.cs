using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Upnodo.Features.Mood.Domain
{
    
    public class MoodRecord
    {
        public MoodRecord(
            DateTime dateCreated, 
            Mood mood, 
            string moodRecordId, 
            string userId)
        {
            DateCreated = dateCreated;
            Mood = mood;
            MoodRecordId = moodRecordId;
            UserId = userId;
        }
        
        public MoodRecord(
            DateTime dateUpdated, 
            Mood mood, 
            string moodRecordId)
        {
            DateUpdated = dateUpdated;
            Mood = mood;
            MoodRecordId = moodRecordId;
        }
        
        [BsonElement("dateCreated")]
        public DateTime DateCreated { get; }
        
        [BsonElement("dateUpdated")]
        public DateTime DateUpdated { get; }

        [BsonElement("mood")]
        public Mood Mood { get; }
        
        [BsonElement("moodRecordId")]
        public string MoodRecordId { get; }

        [BsonElement("userId")]
        public string UserId { get; }
    }
}