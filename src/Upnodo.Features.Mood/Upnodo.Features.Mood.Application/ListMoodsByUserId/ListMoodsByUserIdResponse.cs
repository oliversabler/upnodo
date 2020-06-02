using Upnodo.Domain.Contracts;

namespace Upnodo.Features.Mood.Application.ListMoodsByUserId
{
    public class ListMoodsByUserIdResponse : IResponse
    {
        public ListMoodsByUserIdResponse(bool success, string value)
        {
            Success = success;
            Value = value;
        }
        
        public bool Success { get; }
        
        public string Value { get; }
    }
}