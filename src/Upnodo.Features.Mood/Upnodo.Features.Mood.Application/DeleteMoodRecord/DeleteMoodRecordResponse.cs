using Upnodo.Features.Mood.Application.Contracts;

namespace Upnodo.Features.Mood.Application.DeleteMoodRecord
{
    public class DeleteMoodRecordResponse : BaseResponse
    {
        public DeleteMoodRecordResponse(bool success) : base(success)
        {
        }
    }
}