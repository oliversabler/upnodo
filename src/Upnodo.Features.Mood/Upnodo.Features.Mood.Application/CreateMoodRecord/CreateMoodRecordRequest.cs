using System.ComponentModel.DataAnnotations;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Application.CreateMoodRecord
{
    public class CreateMoodRecordRequest
    {
        public CreateMoodRecordRequest(MoodStatus moodStatus, string userId, string username, string email)
        {
            MoodStatus = moodStatus;
            UserId = userId;
            Username = username;
            Email = email;
        }

        [Required]
        public MoodStatus MoodStatus { get; }
        
        [Required]
        public string UserId { get; }
        
        [Required]
        public string Username { get; }
        
        [Required]
        public string Email { get; }
    }
}