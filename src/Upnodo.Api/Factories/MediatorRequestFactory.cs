using Upnodo.Modules.Records.Application;

namespace Upnodo.Api.Factories
{
    internal static class MediatorRequestFactory
    {
        internal static SaveRecordCommand SaveCommand(SaveRecordRequest recordRequest)
        {
            return new SaveRecordCommand(recordRequest.Mode, recordRequest.UserId);
        }

        internal static ListAllRecordsQuery ListAllRecordsQuery()
        {
            return new ListAllRecordsQuery();
        }
        
        internal static ListRecordsByUserIdQuery ListRecordsByUserIdQuery(string userId)
        {
            return new ListRecordsByUserIdQuery(userId);
        }
    }
}