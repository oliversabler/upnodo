using MediatR;

namespace Upnodo.Features.Mood.Application.GetMoodRecordsByUserId
{
    public class GetMoodRecordsByUserIdQuery : IRequest<GetMoodRecordsByUserIdResponse>
    {
        public string UserId { get; }

        public GetMoodRecordsByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}