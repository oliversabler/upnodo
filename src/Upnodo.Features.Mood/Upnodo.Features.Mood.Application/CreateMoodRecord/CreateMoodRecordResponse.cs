using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.Mood.Application.CreateMoodRecord
{
    public class CreateMoodRecordResponse : BaseResponse
    {
        public CreateMoodRecordResponse(bool success, object value) : base(success, value)
        {
        }
    }
}