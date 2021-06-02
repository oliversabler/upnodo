using MongoDB.Bson.Serialization.Attributes;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Infrastructure.Collections
{
    // Todo: Need better name
    public class MoodRecordUserCollection
    {
        [BsonElement(Constants.Elements.UserId)]
        public string UserId { get; set; }

        [BsonElement(Constants.Elements.Username)]
        public string Username { get; set; }

        [BsonElement(Constants.Elements.Email)]
        public string Email { get; set; }
    }
}