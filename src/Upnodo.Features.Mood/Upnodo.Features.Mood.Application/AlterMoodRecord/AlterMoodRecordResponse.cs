using Upnodo.Features.Mood.Application.Contracts;

namespace Upnodo.Features.Mood.Application.AlterMoodRecord
{
    public class AlterMoodRecordResponse : IResponse
    {
        public AlterMoodRecordResponse(bool success, string value)
        {
            Success = success;
            Value = value;
        }

        public bool Success { get; }
        
        public string Value { get; }
    }
}