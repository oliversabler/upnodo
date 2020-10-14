using MediatR;

namespace Upnodo.Features.Mood.Application.GetMoodRecordsByUserGuid
{
    public class GetMoodRecordsByUserGuidQuery : IRequest<GetMoodRecordsByUserGuidResponse>
    {
        public GetMoodRecordsByUserGuidQuery(string userId)
        {
            UserId = userId;
        }
        
        public string UserId { get; }
    }
}