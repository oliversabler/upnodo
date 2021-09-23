using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.Mood.Application.UpdateMoodRecord
{
    public class UpdateMoodRecordResponse : BaseResponse
    {
        public UpdateMoodRecordResponse(bool success, object value) : base(success, value)
        {
        }
    }
}