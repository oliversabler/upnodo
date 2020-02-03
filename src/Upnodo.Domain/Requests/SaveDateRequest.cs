using System;
using Upnodo.Domain.Enums;

namespace Upnodo.Domain.Requests
{
    public class SaveDateRequest
    {
        public Guid Guid { get; set; }
        
        public Mode Mode { get; set; }

        public DateTime Date { get; set; }
    }
}