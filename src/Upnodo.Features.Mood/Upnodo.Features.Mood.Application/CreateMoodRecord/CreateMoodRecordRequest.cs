using System.ComponentModel.DataAnnotations;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Application.CreateMoodRecord
{
    public class CreateMoodRecordRequest
    {
        [Required]
        public MoodStatus MoodStatus { get; }

        [Required]
        public string UserId { get; }

        [Required]
        public string Username { get; }

        [Required]
        public string Email { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public CreateMoodRecordRequest(
            MoodStatus moodStatus,
            string userId,
            string username,
            string email,
            string firstname,
            string lastname)
        {
            MoodStatus = moodStatus;
            UserId = userId;
            Username = username;
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}