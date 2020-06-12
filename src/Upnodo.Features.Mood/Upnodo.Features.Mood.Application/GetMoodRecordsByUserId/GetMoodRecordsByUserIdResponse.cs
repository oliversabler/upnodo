using Upnodo.Features.Mood.Application.Contracts;

namespace Upnodo.Features.Mood.Application.GetMoodRecordsByUserId
{
    public class GetMoodRecordsByUserIdResponse : BaseResponse
    {
        public GetMoodRecordsByUserIdResponse(bool success, string value) : base(success, value)
        {
        }
    }
}