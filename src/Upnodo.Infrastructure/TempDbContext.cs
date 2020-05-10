using System.IO;
using System.Text.Json;
using Upnodo.Infrastructure.Models;

namespace Upnodo.Infrastructure
{
    public class TempDbContext : ITempDbContext
    {
        public void SaveRecord(string value)
        {
            var tempDbFile = File.ReadAllText("tempdb.json");
            var tempDb = JsonSerializer.Deserialize<TempDb>(tempDbFile);
            var record = JsonSerializer.Deserialize<Record>(value);

            tempDb.Records.Add(record);

            var tempDbUpdate = JsonSerializer.Serialize(tempDb);
            
            File.WriteAllText("tempdb.json", tempDbUpdate);
        }
    }
}