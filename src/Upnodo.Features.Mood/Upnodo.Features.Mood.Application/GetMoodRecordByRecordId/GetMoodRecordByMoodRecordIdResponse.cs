using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.Mood.Application.GetMoodRecordByRecordId
{
    public class GetMoodRecordByMoodRecordIdResponse : BaseResponse
    {
        public GetMoodRecordByMoodRecordIdResponse(bool success, object value) : base(success, value)
        {
        }
    }
}