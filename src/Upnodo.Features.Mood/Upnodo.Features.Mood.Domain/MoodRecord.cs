using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Upnodo.Features.Mood.Domain
{
    // Todo: I feel like we dont need these domain models
    public class MoodRecord
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement(Constants.Elements.MoodRecordId)]
        public string MoodRecordId { get; }

        [BsonElement(Constants.Elements.DateCreated)]
        public DateTime DateCreated { get; }

        [BsonElement(Constants.Elements.DateUpdated)]
        public DateTime DateUpdated { get; }

        [BsonElement(Constants.Elements.Mood)]
        public MoodStatus MoodStatus { get; }

        [BsonElement(Constants.Elements.User)]
        public User? User { get; }

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
            DateTime dateUpdated,
            MoodStatus moodStatus)
        {
            MoodRecordId = moodRecordId;
            DateUpdated = dateUpdated;
            MoodStatus = moodStatus;
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

        public static MoodRecord CreateMood(
            string moodRecordId,
            DateTime dateCreated,
            DateTime dateUpdated,
            MoodStatus moodStatus,
            string userId,
            string username,
            string email)
        {
            return new(moodRecordId, dateCreated, dateUpdated, moodStatus, CreateUser(userId, username, email));
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

        private static User CreateUser(string userId, string username, string email)
        {
            return User.CreateUser(userId, username, email);
        }
    }
}