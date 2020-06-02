using System.IO;
using System.Linq;
using System.Text.Json;
using Upnodo.Features.Mood.Domain.SaveMood;

namespace Upnodo.Features.Mood.Infrastructure
{
    public class TempDbContext : ITempDbContext
    {
        public string ListAllMoods()
        {
            var tempDbFile = File.ReadAllText("tempdb.json");
            var tempDb = JsonSerializer.Deserialize<MoodDb>(tempDbFile);

            var records = tempDb.Records;
            if (!records.Any())
            {
                return "No records found for user";
            }

            return JsonSerializer.Serialize(records);
        }
        
        public string ListMoodsByUserId(string userId)
        {
            var tempDbFile = File.ReadAllText("tempdb.json");
            var tempDb = JsonSerializer.Deserialize<MoodDb>(tempDbFile);

            var records = tempDb.Records.Where(r => r.UserId == userId);
            if (!records.Any())
            {
                return "No records found for user";
            }

            return JsonSerializer.Serialize(tempDb);
        }
        
        public void SaveMood(string value)
        {
            var tempDbFile = File.ReadAllText("tempdb.json");
            var tempDb = JsonSerializer.Deserialize<MoodDb>(tempDbFile);
            var record = JsonSerializer.Deserialize<SaveMoodRecord>(value);

            tempDb.Records.Add(record);

            var tempDbUpdate = JsonSerializer.Serialize(tempDb);

            File.WriteAllText("tempdb.json", tempDbUpdate);
        }
    }
}