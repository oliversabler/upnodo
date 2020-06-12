using Upnodo.Features.Mood.Application.Contracts;

namespace Upnodo.Features.Mood.Application.AlterMoodRecord
{
    public class AlterMoodRecordResponse : BaseResponse
    {
        public AlterMoodRecordResponse(bool success, string value) : base(success, value)
        {
        }
    }
}