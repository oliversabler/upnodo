using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Upnodo.Features.Mood.Domain.Models.CreateMoodRecord
{
    public class CreateMoodRecordCommand : IRequest<CreateMoodRecordResponse>
    {
        public string MoodRecordId { get; }

        public DateTime DateCreated { get; }

        [Required]
        public MoodStatus MoodStatus { get; }

        [Required]
        public string UserId { get; }

        public string Username { get; }

        public string Email { get; }

        public CreateMoodRecordCommand(
            MoodStatus moodStatus,
            string userId,
            string username,
            string email)
        {
            MoodRecordId = Guid.NewGuid().ToString();
            DateCreated = DateTime.UtcNow;
            MoodStatus = moodStatus;
            UserId = userId;
            Username = username;
            Email = email;
        }
    }
}