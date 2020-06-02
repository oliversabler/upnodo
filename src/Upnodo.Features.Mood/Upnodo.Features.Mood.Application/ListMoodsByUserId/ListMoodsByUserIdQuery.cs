using MediatR;

namespace Upnodo.Features.Mood.Application.ListMoodsByUserId
{
    public class ListMoodsByUserIdQuery : IRequest<ListMoodsByUserIdResponse>
    {
        public ListMoodsByUserIdQuery(string userId)
        {
            UserId = userId;
        }
        
        public string UserId { get; }
    }
}