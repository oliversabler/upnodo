using System;
using Upnodo.Domain.Enums;

namespace Upnodo.Domain.Requests.Records
{
    public class SaveRequest
    {
        public Guid Guid { get; set; }
        
        public Mode Mode { get; set; }

        public DateTime Date { get; set; }
    }
}