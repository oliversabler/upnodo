using MongoDB.Bson.Serialization.Attributes;

namespace Upnodo.Features.Mood.Domain
{
    public class User
    {
        [BsonElement(Constants.Elements.UserId)]
        public string? UserId { get; }

        [BsonElement(Constants.Elements.Username)]
        public string? Username { get; }

        [BsonElement(Constants.Elements.Email)]
        public string? Email { get; }

        private User(string userId, string username, string email)
        {
            UserId = userId;
            Username = username;
            Email = email;
        }

        public static User CreateUser(string userId, string username, string email)
        {
            return new(userId, username, email);
        }
    }
}