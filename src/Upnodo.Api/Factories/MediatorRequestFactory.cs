using Upnodo.Features.Mood.Application.SaveMood;
using Upnodo.Modules.Records.Application;

namespace Upnodo.Api.Factories
{
    internal static class MediatorRequestFactory
    {
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