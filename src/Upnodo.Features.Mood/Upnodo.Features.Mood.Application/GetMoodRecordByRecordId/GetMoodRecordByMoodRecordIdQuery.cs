using MediatR;

namespace Upnodo.Features.Mood.Application.GetMoodRecordByRecordId
{
    public class GetMoodRecordByMoodRecordIdQuery : IRequest<GetMoodRecordByMoodRecordIdResponse>
    {
        public string MoodRecordId { get; }

        public GetMoodRecordByMoodRecordIdQuery(string moodRecordId)
        {
            MoodRecordId = moodRecordId;
        }
    }
}