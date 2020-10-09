using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.Mood.Application.GetAllMoodRecords
{
    public class GetAllMoodRecordsResponse : BaseResponse
    {
        public GetAllMoodRecordsResponse(bool success, string value) : base(success, value)
        {
        }
    }
}