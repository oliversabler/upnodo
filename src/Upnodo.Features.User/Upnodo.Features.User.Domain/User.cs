using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Upnodo.Features.User.Domain
{
    public class User
    {
        public User(
            string alias, 
            DateTime date, 
            string email, 
            string firstname, 
            string userId, 
            string lastname)
        {
            Alias = alias;
            Date = date;
            Email = email;
            Firstname = firstname;
            UserId = userId;
            Lastname = lastname;
        }
        
        [BsonElement("alias")]
        private string Alias { get; }
        
        [BsonElement("date")]
        private DateTime Date { get; }
        
        [BsonElement("email")]
        private string Email { get; }

        [BsonElement("firstname")]
        private string Firstname { get; }

        [BsonElement("userId")]
        private string UserId { get; }

        [BsonElement("lastname")]
        private string Lastname { get; }
    }
}