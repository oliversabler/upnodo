using MediatR;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.BuildingBlocks.Application.Models;

namespace Upnodo.Features.Mood.Application.GetMoodRecordByRecordId
{
    public class GetMoodRecordByMoodRecordIdQuery : IRequest<GetMoodRecordByMoodRecordIdResponse>, ICacheableQuery
    {
        public string MoodRecordId { get; }

        public Cache? Cache { get; set; }

        public GetMoodRecordByMoodRecordIdQuery(string moodRecordId, Cache? cache)
        {
            MoodRecordId = moodRecordId;

            if (cache != null)
            {
                Cache = new Cache
                {
                    CacheKey = moodRecordId,
                    BypassCache = cache.BypassCache
                };
            }
        }
    }
}