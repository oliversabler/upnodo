using System.Collections.Generic;
using Upnodo.Features.Mood.Application.Contracts;
using Upnodo.Features.Mood.Domain.SaveMood;

namespace Upnodo.Features.Mood.Application.GetMoodRecordsByUserId
{
    public class GetMoodRecordsByUserIdResponse : BaseResponse
    {
        public GetMoodRecordsByUserIdResponse(bool success, List<MoodRecord> value) : base(success, value)
        {
        }
    }
}