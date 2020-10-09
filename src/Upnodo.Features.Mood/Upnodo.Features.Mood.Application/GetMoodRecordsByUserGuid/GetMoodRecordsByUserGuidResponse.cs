using System.Collections.Generic;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Application.GetMoodRecordsByUserGuid
{
    public class GetMoodRecordsByUserGuidResponse : BaseResponse
    {
        public GetMoodRecordsByUserGuidResponse(bool success, List<MoodRecord> value) : base(success, value)
        {
        }
    }
}