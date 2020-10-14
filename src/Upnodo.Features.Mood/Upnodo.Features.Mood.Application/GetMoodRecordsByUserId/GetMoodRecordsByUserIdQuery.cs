using MediatR;

namespace Upnodo.Features.Mood.Application.GetMoodRecordsByUserId
{
    public class GetMoodRecordsByUserIdQuery : IRequest<GetMoodRecordsByUserIdResponse>
    {
        public GetMoodRecordsByUserIdQuery(string userId)
        {
            UserId = userId;
        }
        
        public string UserId { get; }
    }
}