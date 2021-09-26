using MediatR;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Models;

namespace Upnodo.Features.User.Application.GetUserByUserId
{
    public class GetUserByUserIdQuery : IRequest<GetUserByUserIdResponse>, ICacheableQuery
    {
        public string MoodRecordId { get; }

        public Cache? Cache { get; set; }

        public GetUserByUserIdQuery(string moodRecordId, Cache? cache)
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
