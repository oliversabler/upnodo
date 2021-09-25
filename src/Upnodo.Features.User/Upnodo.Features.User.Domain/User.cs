using System;

namespace Upnodo.Features.User.Domain
{
    public class User
    {
        public string? UserId { get; }

        public string? Username { get; }

        public string? Email { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string Fullname { get; }

        public DateTime DateCreated { get; }

        public DateTime DateUpdated { get; }

        public User(
            string userId,
            string username,
            string email,
            string firstname,
            string lastname,
            DateTime dateUpdated)
        {
            UserId = userId;
            Username = username;
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
            Fullname = $"{firstname} {lastname}";
            DateUpdated = dateUpdated;
        }

        private User(
            string userId,
            string username,
            string email,
            string firstname,
            string lastname,
            DateTime dateCreated,
            DateTime dateUpdated)
        {
            UserId = userId;
            Username = username;
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
            Fullname = $"{firstname} {lastname}";
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
        }

        public static User CreateUser(
            string userId,
            string username,
            string email,
            string firstname,
            string lastname,
            DateTime dateCreated,
            DateTime dateUpdated)
        {
            return new(userId, username, email, firstname, lastname, dateCreated, dateUpdated);
        }

        public static User UpdateUser(
            string userId,
            string username,
            string email,
            string firstname,
            string lastname,
            DateTime dateUpdated)
        {
            return new(userId, username, email, firstname, lastname, dateUpdated);
        }
    }
}