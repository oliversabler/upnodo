using MediatR;
using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.Mood.Application.GetMoodRecordByRecordId
{
    public class GetMoodRecordByMoodRecordIdQuery : IRequest<GetMoodRecordByMoodRecordIdResponse>, ICacheableQuery
    {
        public string MoodRecordId { get; }

        public string CacheKey { get; }
        public bool BypassCache { get; }

        public GetMoodRecordByMoodRecordIdQuery(string moodRecordId, bool bypassCache)
        {
            CacheKey = moodRecordId;
            MoodRecordId = moodRecordId;
            BypassCache = bypassCache;
        }
    }
}