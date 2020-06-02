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
            var user = JsonSerializer.Deserialize<User>(tempDbFile);

            var records = user.Records;
            if (!records.Any())
            {
                return "No records found for user";
            }

            return JsonSerializer.Serialize(records);
        }
        
        public string ListMoodsByUserId(string userId)
        {
            var tempDbFile = File.ReadAllText("tempdb.json");
            var user = JsonSerializer.Deserialize<User>(tempDbFile);

            var records = user.Records.Where(r => r.UserId == userId).ToList();
            if (!records.Any())
            {
                return "No records found for user";
            }

            return JsonSerializer.Serialize(records);
        }
        
        public void SaveMood(string value)
        {
            var tempDbFile = File.ReadAllText("tempdb.json");
            var user = JsonSerializer.Deserialize<User>(tempDbFile);
            var record = JsonSerializer.Deserialize<SaveMoodRecord>(value);

            user.Records.Add(record);

            var tempDbUpdate = JsonSerializer.Serialize(user);

            File.WriteAllText("tempdb.json", tempDbUpdate);
        }
    }
}