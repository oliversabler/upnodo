using Upnodo.Domain.Contracts;

namespace Upnodo.Modules.Records.Application
{
    public class SaveResponse : IResponse
    {
        public SaveResponse(bool success, string value)
        {
            Success = success;
            Value = value;
        }
        
        public bool Success { get; }
        
        public string Value { get; }
    }
}