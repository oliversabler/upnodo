using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Application.DeleteMoodRecord;
using Upnodo.Features.Mood.Application.GetMoodRecordsByUserGuid;
using Upnodo.Features.Mood.Application.UpdateMoodRecord;

namespace Upnodo.Api.Features.Mood.Configurations
{
    internal static class MediatorRequestFactory
    {
        internal static CreateMoodRecordCommand CreateMoodRecordCommand(CreateMoodRecordRequest recordRequest)
        {
            return new CreateMoodRecordCommand(recordRequest.Mood, recordRequest.UserId);
        }

        internal static DeleteMoodRecordCommand DeleteMoodRecordCommand(string moodId)
        {
            return new DeleteMoodRecordCommand(moodId);
        }

        internal static GetMoodRecordsByUserGuidQuery GetMoodRecordsByUserGuidQuery(string userId)
        {
            return new GetMoodRecordsByUserGuidQuery(userId);
        }
        
        internal static UpdateMoodRecordCommand UpdateMoodRecordCommand(UpdateMoodRecordRequest updateMoodRecordRequest)
        {
            return new UpdateMoodRecordCommand(updateMoodRecordRequest.Mood, updateMoodRecordRequest.MoodRecordId);
        }
    }
}