using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.Mood.Application.AlterMoodRecord
{
    public class AlterMoodRecordResponse : BaseResponse
    {
        public AlterMoodRecordResponse(bool success, object value) : base(success, value)
        {
        }
    }
}