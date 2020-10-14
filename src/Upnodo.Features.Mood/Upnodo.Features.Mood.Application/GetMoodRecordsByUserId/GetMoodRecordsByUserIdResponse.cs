using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.Mood.Application.GetMoodRecordsByUserId
{
    public class GetMoodRecordsByUserIdResponse : BaseResponse
    {
        public GetMoodRecordsByUserIdResponse(bool success, object value) : base(success, value)
        {
        }
    }
}