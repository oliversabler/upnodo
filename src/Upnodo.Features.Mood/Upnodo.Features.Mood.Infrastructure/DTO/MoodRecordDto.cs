using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Infrastructure.DTO
{
    // Todo: Should we take a look at AutoMapper?
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