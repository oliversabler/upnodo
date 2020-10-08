using System;
using MediatR;

namespace Upnodo.Features.Mood.Application.GetMoodRecordsByUserGuid
{
    public class GetMoodRecordsByUserGuidQuery : IRequest<GetMoodRecordsByUserGuidResponse>
    {
        public GetMoodRecordsByUserGuidQuery(Guid userGuid)
        {
            UserGuid = userGuid;
        }
        
        public Guid UserGuid { get; }
    }
}