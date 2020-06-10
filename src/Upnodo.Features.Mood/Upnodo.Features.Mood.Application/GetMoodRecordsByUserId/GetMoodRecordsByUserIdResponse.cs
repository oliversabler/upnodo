using Upnodo.Features.Mood.Application.Contracts;

namespace Upnodo.Features.Mood.Application.GetMoodRecordsByUserId
{
    public class GetMoodRecordsByUserIdResponse : IResponse
    {
        public GetMoodRecordsByUserIdResponse(bool success, string value)
        {
            Success = success;
            Value = value;
        }
        
        public bool Success { get; }
        
        public string Value { get; }
    }
}