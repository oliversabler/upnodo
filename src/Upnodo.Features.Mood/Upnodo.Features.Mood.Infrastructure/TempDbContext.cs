using System.IO;
using System.Linq;
using System.Text.Json;
using Upnodo.Features.Mood.Domain.SaveMood;

namespace Upnodo.Features.Mood.Infrastructure
{
    public class TempDbContext : ITempDbContext
    {
        public void CreateMoodRecord(string value)
        {
            var tempDbFile = File.ReadAllText("tempdb.json");
            var user = JsonSerializer.Deserialize<User>(tempDbFile);
            var record = JsonSerializer.Deserialize<MoodRecord>(value);

            user.MoodRecords.Add(record);

            var tempDbUpdate = JsonSerializer.Serialize(user);

            File.WriteAllText("tempdb.json", tempDbUpdate);
        }
        
        public string GetAllMoodRecords()
        {
            var tempDbFile = File.ReadAllText("tempdb.json");
            var user = JsonSerializer.Deserialize<User>(tempDbFile);

            var records = user.MoodRecords;
            if (!records.Any())
            {
                return "No records found in database.";
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
                return "No records found for user.";
            }

            return JsonSerializer.Serialize(records);
        }
    }
}