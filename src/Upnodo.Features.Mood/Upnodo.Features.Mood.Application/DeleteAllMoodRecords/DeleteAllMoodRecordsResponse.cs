using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.Mood.Application.DeleteAllMoodRecords
{
    public class DeleteAllMoodRecordsResponse : BaseResponse
    {
        public DeleteAllMoodRecordsResponse(bool success, object value) : base(success, value)
        {
        }
    }
}