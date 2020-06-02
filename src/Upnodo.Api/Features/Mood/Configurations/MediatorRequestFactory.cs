using Upnodo.Features.Mood.Application.ListAllMoods;
using Upnodo.Features.Mood.Application.ListMoodsByUserId;
using Upnodo.Features.Mood.Application.SaveMood;

namespace Upnodo.Api.Features.Mood.Configurations
{
    internal static class MediatorRequestFactory
    {
        internal static ListAllMoodsQuery ListAllMoodsQuery()
        {
            return new ListAllMoodsQuery();
        }

        internal static ListMoodsByUserIdQuery ListMoodsByUserIdQuery(string userId)
        {
            return new ListMoodsByUserIdQuery(userId);
        }
        
        internal static SaveMoodCommand SaveMoodCommand(SaveMoodRequest request)
        {
            return new SaveMoodCommand(request.Mood, request.UserId);
        }
    }
}