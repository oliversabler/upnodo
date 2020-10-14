using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Upnodo.Features.User.Domain
{
    public class User
    {
        [BsonElement("alias")]
        public string Alias { get; set; }
        
        [BsonElement("date")]
        public DateTime Date { get; set; }
        
        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("firstname")]
        public string Firstname { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("lastname")]
        public string Lastname { get; set; }
    }
}