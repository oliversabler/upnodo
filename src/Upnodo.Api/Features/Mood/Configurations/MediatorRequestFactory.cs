using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Application.GetAllMoodRecords;
using Upnodo.Features.Mood.Application.GetMoodRecordsByUserId;

namespace Upnodo.Api.Features.Mood.Configurations
{
    internal static class MediatorRequestFactory
    {
        internal static CreateMoodRecordCommand CreateMoodRecordCommand(CreateMoodRecordRequest recordRequest)
        {
            return new CreateMoodRecordCommand(recordRequest.Mood, recordRequest.UserId);
        }
        
        internal static GetAllMoodRecordsQuery GetAllMoodRecordsQuery()
        {
            return new GetAllMoodRecordsQuery();
        }

        internal static GetMoodRecordsByUserIdQuery GetMoodRecordsByUserIdQuery(string userId)
        {
            return new GetMoodRecordsByUserIdQuery(userId);
        }
    }
}