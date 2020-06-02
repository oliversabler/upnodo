using Upnodo.Features.Mood.Application.ListAllMoods;
using Upnodo.Features.Mood.Application.ListMoodsByUserId;
using Upnodo.Features.Mood.Application.SaveMood;

namespace Upnodo.Api.Features.Mood.Configurations
{
    internal static class MediatorRequestFactory
    {
        internal static SaveMoodCommand SaveMoodCommand(SaveMoodRequest request)
        {
            return new SaveMoodCommand(request.Mood, request.UserId);
        }

        internal static ListAllMoodsQuery ListAllMoodsQuery(ListAllMoodsRequest request)
        {
            return new ListAllMoodsQuery();
        }

        internal static ListMoodsByUserIdQuery ListMoodsByUserIdQuery(ListMoodsByUserIdRequest request)
        {
            return new ListMoodsByUserIdQuery(request.UserId);
        }
    }
}