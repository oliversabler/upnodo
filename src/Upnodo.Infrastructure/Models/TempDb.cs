using System.Collections.Generic;

namespace Upnodo.Infrastructure.Models
{
    public class TempDb
    {
        public TempDb()
        {
            if (Records == null)
            {
                Records = new List<Record>();
            }
        }
        
        public List<Record> Records { get; set; }
    }
}