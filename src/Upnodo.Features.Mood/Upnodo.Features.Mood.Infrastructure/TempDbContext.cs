using System.IO;
using System.Text.Json;
using Upnodo.Features.Mood.Domain.SaveMood;

namespace Upnodo.Features.Mood.Infrastructure
{
    public class TempDbContext : ITempDbContext
    {
        public void SaveMood(string value)
        {
            var tempDbFile = File.ReadAllText("tempdb.json");
            var tempDb = JsonSerializer.Deserialize<SaveMood>(tempDbFile);
            var record = JsonSerializer.Deserialize<SaveMoodRecord>(value);

            tempDb.Records.Add(record);

            var tempDbUpdate = JsonSerializer.Serialize(tempDb);
            
            File.WriteAllText("tempdb.json", tempDbUpdate);
        }
    }
}