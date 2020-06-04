using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Upnodo.Features.Mood.Domain.SaveMood;

namespace Upnodo.Features.Mood.Infrastructure
{
    // Todo: Db only support one User atm, fix.
    public class TempDbContext : ITempDbContext
    {
        public void CreateMoodRecord(string value)
        {
            var tempDbFile = File.ReadAllText("tempdb.json");
            var user = JsonSerializer.Deserialize<User>(tempDbFile);
            var record = JsonSerializer.Deserialize<MoodRecord>(value);

            user.MoodRecords.Add(record);

            var userUpdate = JsonSerializer.Serialize(user);

            File.WriteAllText("tempdb.json", userUpdate);
        }

        public void DeleteMoodRecord(Guid guid)
        {
            var tempDbFile = File.ReadAllText("tempdb.json");
            var user = JsonSerializer.Deserialize<User>(tempDbFile);

            var recordToDelete = user?.MoodRecords?.First(record => record.Guid == guid);
            if (recordToDelete == null)
            {
                // Todo: Log
                throw new NullReferenceException($"Object reference ({nameof(recordToDelete)}) is not set to an instance of an object.");
            }
            
            user.MoodRecords.Remove(recordToDelete);
            
            var userUpdate = JsonSerializer.Serialize(user);
            
            File.WriteAllText("tempdb.json", userUpdate);
        }

        public string GetAllMoodRecords()
        {
            var tempDbFile = File.ReadAllText("tempdb.json");
            var user = JsonSerializer.Deserialize<User>(tempDbFile);

            var records = user.MoodRecords;
            if (!records.Any())
            {
                // Todo: Log
                throw new InvalidOperationException($"Sequence ({nameof(records)}) contains now elements.");
            }

            return JsonSerializer.Serialize(records);
        }
        
        public string GetMoodRecordsByUserId(string userId)
        {
            var tempDbFile = File.ReadAllText("tempdb.json");
            var user = JsonSerializer.Deserialize<User>(tempDbFile);

            var records = user.MoodRecords.Where(r => r.UserId == userId).ToList();
            if (!records.Any())
            {
                // Todo: Log
                throw new InvalidOperationException($"Sequence ({nameof(records)}) contains now elements.");
            }

            return JsonSerializer.Serialize(records);
        }
    }
}