using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Application.DeleteAllMoodRecords;
using Upnodo.Features.Mood.Application.DeleteMoodRecord;
using Upnodo.Features.Mood.Application.GetLatestCreatedMoodRecords;
using Upnodo.Features.Mood.Application.GetMoodRecordByRecordId;
using Upnodo.Features.Mood.Application.UpdateMoodRecord;

namespace Upnodo.Api.Features.Mood
{
    internal static class MediatorRequestFactory
    {
        internal static CreateMoodRecordCommand CreateMoodRecordCommand(CreateMoodRecordRequest request)
        {
            return new(
                request.MoodStatus, 
                request.UserId, 
                request.Username, 
                request.Email,
                request.Firstname,
                request.Lastname);
        }

        internal static DeleteAllMoodRecordsCommand DeleteAllMoodRecordsCommand()
        {
            return new();
        }

        internal static DeleteMoodRecordCommand DeleteMoodRecordCommand(string moodId)
        {
            return new(moodId);
        }

        internal static GetMoodRecordByMoodRecordIdQuery GetMoodRecordByMoodRecordIdQuery(
            GetMoodRecordByMoodRecordIdRequest request)
        {
            return new(request.MoodRecordId, request.Cache);
        }

        internal static GetLatestCreatedMoodRecordsQuery GetLatestCreatedMoodRecordsQuery(int totalNumberOfMoodRecords)
        {
            return new(totalNumberOfMoodRecords);
        }

        internal static UpdateMoodRecordCommand UpdateMoodRecordCommand(UpdateMoodRecordRequest request)
        {
            return new(request.MoodRecordId, request.MoodStatus);
        }
    }
}