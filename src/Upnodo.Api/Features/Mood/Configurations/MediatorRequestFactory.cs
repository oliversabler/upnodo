using Upnodo.Features.Mood.Application.SaveMood;

namespace Upnodo.Api.Features.Mood.Configurations
{
    internal static class MediatorRequestFactory
    {
        internal static SaveMoodCommand SaveMoodCommand(SaveMoodRequest recordRequest)
        {
            return new SaveMoodCommand(recordRequest.Mood, recordRequest.UserId);
        }
    }
}