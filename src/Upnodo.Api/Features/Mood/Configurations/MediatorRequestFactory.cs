using System;
using Upnodo.Features.Mood.Application.AlterMoodRecord;
using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Application.DeleteMoodRecord;
using Upnodo.Features.Mood.Application.GetAllMoodRecords;
using Upnodo.Features.Mood.Application.GetMoodRecordsByUserGuid;

namespace Upnodo.Api.Features.Mood.Configurations
{
    internal static class MediatorRequestFactory
    {
        internal static AlterMoodRecordCommand AlterMoodRecordCommand(AlterMoodRecordRequest alterMoodRecordRequest)
        {
            return new AlterMoodRecordCommand(alterMoodRecordRequest.Mood, alterMoodRecordRequest.MoodRecordId);
        }
        
        internal static CreateMoodRecordCommand CreateMoodRecordCommand(CreateMoodRecordRequest recordRequest)
        {
            return new CreateMoodRecordCommand(recordRequest.Mood, recordRequest.UserId);
        }
        
        internal static DeleteMoodRecordCommand DeleteMoodRecordCommand(string moodId)
        {
            return new DeleteMoodRecordCommand(moodId);
        }
        
        internal static GetAllMoodRecordsQuery GetAllMoodRecordsQuery()
        {
            return new GetAllMoodRecordsQuery();
        }

        internal static GetMoodRecordsByUserGuidQuery GetMoodRecordsByUserGuidQuery(string userId)
        {
            return new GetMoodRecordsByUserGuidQuery(userId);
        }
    }
}