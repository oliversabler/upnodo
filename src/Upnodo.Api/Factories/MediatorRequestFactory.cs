using Upnodo.Modules.Records.Application;

namespace Upnodo.Api.Factories
{
    internal static class MediatorRequestFactory
    {
        internal static SaveCommand SaveCommand(SaveRequest request)
        {
            return new SaveCommand(request.Mode, request.UserId);
        }

        internal static ListQuery ListQuery(ListRequest request)
        {
            return new ListQuery();
        }
    }
}