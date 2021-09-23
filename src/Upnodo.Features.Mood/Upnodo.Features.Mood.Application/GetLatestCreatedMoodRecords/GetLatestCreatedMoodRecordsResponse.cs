using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.Mood.Application.GetLatestCreatedMoodRecords
{
    public class GetLatestCreatedMoodRecordsResponse : BaseResponse
    {
        public GetLatestCreatedMoodRecordsResponse(bool success, object value) : base(success, value)
        {
        }
    }
}