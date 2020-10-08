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
            return new AlterMoodRecordCommand(alterMoodRecordRequest.Guid, alterMoodRecordRequest.Mood);
        }
        
        internal static CreateMoodRecordCommand CreateMoodRecordCommand(CreateMoodRecordRequest recordRequest)
        {
            return new CreateMoodRecordCommand(recordRequest.Mood, recordRequest.UserId);
        }
        
        internal static DeleteMoodRecordCommand DeleteMoodRecordCommand(Guid guid)
        {
            return new DeleteMoodRecordCommand(guid);
        }
        
        internal static GetAllMoodRecordsQuery GetAllMoodRecordsQuery()
        {
            return new GetAllMoodRecordsQuery();
        }

        internal static GetMoodRecordsByUserGuidQuery GetMoodRecordsByUserGuidQuery(Guid userGuid)
        {
            return new GetMoodRecordsByUserGuidQuery(userGuid);
        }
    }
}