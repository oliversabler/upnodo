using Upnodo.Domain.Contracts;

namespace Upnodo.Features.Mood.Application.SaveMood
{
    public class SaveMoodResponse : IResponse
    {
        public SaveMoodResponse(bool success, string value)
        {
            Success = success;
            Value = value;
        }
        
        public bool Success { get; }
        
        public string Value { get; }
    }
}