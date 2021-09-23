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

        private User(string userId, string username, string email, string firstname, string lastname)
        {
            UserId = userId;
            Username = username;
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
            Fullname = $"{firstname} {lastname}";
        }

        public static User CreateUser(
            string userId,
            string username,
            string email,
            string firstname,
            string lastname)
        {
            return new(userId, username, email, firstname, lastname);
        }
    }
}