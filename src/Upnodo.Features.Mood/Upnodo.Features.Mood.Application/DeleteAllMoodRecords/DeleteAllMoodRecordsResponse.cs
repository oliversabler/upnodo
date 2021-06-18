using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.Mood.Application.DeleteAllMoodRecords
{
    public class DeleteAllMoodRecordsResponse : BaseResponse
    {
        public DeleteAllMoodRecordsResponse(bool success) : base(success)
        {
        }
    }
}