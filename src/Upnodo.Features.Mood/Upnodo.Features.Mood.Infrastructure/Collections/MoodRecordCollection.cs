using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Infrastructure.Collections
{
    // Todo: Horrible name, fix
    public class MoodRecordCollection
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        [BsonElement(Constants.Elements.MoodRecordId)]
        public string MoodRecordId { get; set; }

        [BsonElement(Constants.Elements.DateCreated)]
        public DateTime DateCreated { get; set; }

        [BsonElement(Constants.Elements.DateUpdated)]
        public DateTime DateUpdated { get; set; }

        [BsonElement(Constants.Elements.Mood)]
        public MoodStatus MoodStatus { get; set; }

        [BsonElement(Constants.Elements.User)]
        public MoodRecordCollectionUser User { get; set; }
    }
}