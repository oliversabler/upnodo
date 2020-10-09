using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Upnodo.Features.User.Domain
{
    public class User
    {
        public string Alias { get; set; }

        public DateTime Date { get; set; }
        
        public string Email { get; set; }

        public string Firstname { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Guid { get; set; }
        
        public string Lastname { get; set; }

        public List<Guid> MoodRecordGuids { get; set; }
    }
}