using MediatR;

namespace Upnodo.Modules.Records.Application
{
    public class ListRecordsByUserIdQuery : IRequest<ListRecordsByUserIdResponse>
    {
        public ListRecordsByUserIdQuery(string userId)
        {
            UserId = userId;
        }
        
        internal string UserId { get; }
    }
}