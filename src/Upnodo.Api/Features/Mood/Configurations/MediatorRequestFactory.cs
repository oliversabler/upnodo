using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Application.DeleteMoodRecord;
using Upnodo.Features.Mood.Application.GetMoodRecordByRecordId;
using Upnodo.Features.Mood.Application.UpdateMoodRecord;

namespace Upnodo.Api.Features.Mood.Configurations
{
    internal static class MediatorRequestFactory
    {
        internal static CreateMoodRecordCommand CreateMoodRecordCommand(CreateMoodRecordRequest recordRequest)
        {
            return new(recordRequest.MoodStatus, recordRequest.UserId, recordRequest.Username, recordRequest.Email);
        }

        internal static DeleteMoodRecordCommand DeleteMoodRecordCommand(string moodId)
        {
            return new(moodId);
        }
        
        internal static GetMoodRecordByMoodRecordIdQuery GetMoodRecordByMoodRecordIdQuery(string userId)
        {
            return new(userId);
        }

        internal static UpdateMoodRecordCommand UpdateMoodRecordCommand(UpdateMoodRecordRequest updateMoodRecordRequest)
        {
            return new(updateMoodRecordRequest.MoodRecordId, updateMoodRecordRequest.MoodStatus);
        }
    }
}