using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Upnodo.Features.Mood.Domain.SaveMood
{
    
    public class MoodRecord
    {
        public DateTime Date { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Guid { get; set; }
        
        public Mood Mood { get; set; }

        public Guid UserGuid { get; set; }
    }
}