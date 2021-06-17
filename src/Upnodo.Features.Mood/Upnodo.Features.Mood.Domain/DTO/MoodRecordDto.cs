using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Upnodo.Features.Mood.Domain.DTO
{
    public class MoodRecordDto
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string MoodRecordId { get; set; }
        
        public DateTime DateCreated { get; set; }
        
        public DateTime DateUpdated { get; set; }
        
        public MoodStatus MoodStatus { get; set; }
        
        public UserDto User { get; set; }
    }
}