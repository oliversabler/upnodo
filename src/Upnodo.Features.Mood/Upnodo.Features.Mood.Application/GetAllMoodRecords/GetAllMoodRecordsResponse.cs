using Upnodo.Domain.Contracts;

namespace Upnodo.Features.Mood.Application.GetAllMoodRecords
{
    public class GetAllMoodRecordsResponse : IResponse
    {
        public GetAllMoodRecordsResponse(bool success, string value)
        {
            Success = success;
            Value = value;
        }
        
        public bool Success { get; }
        
        public string Value { get; }
    }
}