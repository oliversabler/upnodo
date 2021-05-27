using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.Mood.Application.DeleteMoodRecord
{
    public class DeleteMoodRecordResponse : BaseResponse
    {
        public DeleteMoodRecordResponse(bool success, object value) : base(success, value)
        {
        }
    }
}