using System.Collections.Generic;
using Upnodo.Features.Mood.Application.Contracts;
using Upnodo.Features.Mood.Domain.SaveMood;

namespace Upnodo.Features.Mood.Application.GetMoodRecordsByUserGuid
{
    public class GetMoodRecordsByUserGuidResponse : BaseResponse
    {
        public GetMoodRecordsByUserGuidResponse(bool success, List<MoodRecord> value) : base(success, value)
        {
        }
    }
}