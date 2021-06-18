using System;

namespace Upnodo.Features.Mood.Domain
{
    public class MoodRecord
    {
        public string MoodRecordId { get; }

        public DateTime DateCreated { get; }

        public DateTime DateUpdated { get; }

        public MoodStatus MoodStatus { get; }

        public User? User { get; }

        private MoodRecord()
        {
        }

        private MoodRecord(
            string moodRecordId,
            DateTime dateCreated,
            DateTime dateUpdated,
            MoodStatus moodStatus,
            User user)
        {
            MoodRecordId = moodRecordId;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
            MoodStatus = moodStatus;
            User = user;
        }

        private MoodRecord(
            string moodRecordId,
            DateTime dateCreated,
            DateTime dateUpdated,
            MoodStatus moodStatus)
        {
            MoodRecordId = moodRecordId;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
            MoodStatus = moodStatus;
        }

        private MoodRecord(
            string moodRecordId,
            DateTime dateUpdated,
            MoodStatus moodStatus)
        {
            MoodRecordId = moodRecordId;
            DateUpdated = dateUpdated;
            MoodStatus = moodStatus;
        }

        public static MoodRecord CreateMood(
            string moodRecordId,
            DateTime dateCreated,
            DateTime dateUpdated,
            MoodStatus moodStatus,
            string userId,
            string username,
            string email,
            string firstname,
            string lastname)
        {
            return new(
                moodRecordId,
                dateCreated,
                dateUpdated,
                moodStatus,
                CreateUser(userId, username, email, firstname, lastname));
        }

        public static MoodRecord CreateEmpty()
        {
            return new();
        }

        public static MoodRecord UpdateMood(
            string moodRecordId,
            DateTime dateUpdated,
            MoodStatus moodStatus)
        {
            return new(moodRecordId, dateUpdated, moodStatus);
        }

        public static MoodRecord UpdateMood(
            string moodRecordId,
            DateTime dateCreated,
            DateTime dateUpdated,
            MoodStatus moodStatus)
        {
            return new(moodRecordId, dateCreated, dateUpdated, moodStatus);
        }

        private static User CreateUser(
            string userId,
            string username,
            string email,
            string firstname,
            string lastname)
        {
            return User.CreateUser(userId, username, email, firstname, lastname);
        }
    }
}