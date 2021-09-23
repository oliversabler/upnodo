using MediatR;

namespace Upnodo.Features.Mood.Application.DeleteMoodRecord
{
    public class DeleteMoodRecordCommand : IRequest<DeleteMoodRecordResponse>
    {
        public string MoodId { get; }

        public DeleteMoodRecordCommand(string moodId)
        {
            MoodId = moodId;
        }
    }
}