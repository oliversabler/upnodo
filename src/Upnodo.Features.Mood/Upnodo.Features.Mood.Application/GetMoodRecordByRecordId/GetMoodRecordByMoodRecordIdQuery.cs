using MediatR;

namespace Upnodo.Features.Mood.Application.GetMoodRecordByRecordId
{
    public class GetMoodRecordByMoodRecordIdQuery : IRequest<GetMoodRecordByMoodRecordIdResponse>
    {
        public GetMoodRecordByMoodRecordIdQuery(string moodRecordId)
        {
            MoodRecordId = moodRecordId;
        }

        public string MoodRecordId { get; set; }
    }
}