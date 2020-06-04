using Upnodo.Domain.Contracts;

namespace Upnodo.Features.Mood.Application.DeleteMoodRecord
{
    public class DeleteMoodRecordResponse : IResponse
    {
        public DeleteMoodRecordResponse(bool success)
        {
            Success = success;
        }
        
        public bool Success { get; }
    }
}