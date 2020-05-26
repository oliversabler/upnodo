using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Upnodo.Infrastructure.Models;

namespace Upnodo.Infrastructure
{
    public class TempDbContext : ITempDbContext
    {
        public string ListAllRecords()
        {
            var tempDbFile = File.ReadAllText("tempdb.json");
            var tempDb = JsonSerializer.Deserialize<TempDb>(tempDbFile);

            var records = tempDb.Records;
            if (!records.Any())
            {
                return "No records found for user";
            }

            return JsonSerializer.Serialize(records);
        }
        
        public string ListRecordsByUserId(string userId)
        {
            var tempDbFile = File.ReadAllText("tempdb.json");
            var tempDb = JsonSerializer.Deserialize<TempDb>(tempDbFile);

            var records = tempDb.Records.Where(r => r.UserId == userId);
            if (!records.Any())
            {
                return "No records found for user";
            }

            return JsonSerializer.Serialize(tempDb);
        }
        
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