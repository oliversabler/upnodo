using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Application.CreateMoodRecord
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

        public string Firstname { get; }

        public string Lastname { get; }

        public CreateMoodRecordCommand(
            MoodStatus moodStatus,
            string userId,
            string username,
            string email,
            string firstname,
            string lastname)
        {
            MoodRecordId = Guid.NewGuid().ToString();
            DateCreated = DateTime.UtcNow;
            MoodStatus = moodStatus;
            UserId = userId;
            Username = username;
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}