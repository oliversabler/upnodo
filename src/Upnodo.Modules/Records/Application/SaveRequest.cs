using Upnodo.Domain.Enums;

namespace Upnodo.Modules.Records.Application
{
    public class SaveRequest
    {
        public string UserId { get; set; }
        
        public Mode Mode { get; set; }
    }
}