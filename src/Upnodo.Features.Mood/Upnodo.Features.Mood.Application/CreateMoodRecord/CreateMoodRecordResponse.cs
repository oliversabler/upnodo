using Upnodo.Features.Mood.Application.Contracts;

namespace Upnodo.Features.Mood.Application.CreateMoodRecord
{
    public class CreateMoodRecordResponse : BaseResponse
    {
        public CreateMoodRecordResponse(bool success, string value) : base(success, value)
        {
        }
    }
}