using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Upnodo.Features.User.Domain
{
    public class User
    {
        public User(
            string alias,
            DateTime dateCreated,
            string email,
            string firstname,
            string userId,
            string lastname)
        {
            Alias = alias;
            DateCreated = dateCreated;
            Email = email;
            Firstname = firstname;
            UserId = userId;
            Lastname = lastname;
        }

        public User(
            string alias,
            DateTime dateUpdated,
            string email,
            string firstname,
            string lastname)
        {
            Alias = alias;
            DateUpdated = dateUpdated;
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
        }

        [BsonElement("alias")]
        public string Alias { get; }

        [BsonElement("dateCreated")]
        private DateTime DateCreated { get; }

        [BsonElement("dateUpdate")]
        private DateTime DateUpdated { get; }

        [BsonElement("email")]
        public string Email { get; }

        [BsonElement("firstname")]
        public string Firstname { get; }

        [BsonElement("userId")]
        public string UserId { get; }

        [BsonElement("lastname")]
        public string Lastname { get; }
    }
}