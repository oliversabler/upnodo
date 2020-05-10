using System;
using Upnodo.Domain.Enums;

namespace Upnodo.Infrastructure.Models
{
    public class Record
    {
        public Guid Guid { get; set; }
        
        public Mode Mode { get; set; }

        public DateTime Date { get; set; }
    }
}