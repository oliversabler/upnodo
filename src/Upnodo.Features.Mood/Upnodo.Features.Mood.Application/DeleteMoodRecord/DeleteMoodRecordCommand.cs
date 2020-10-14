using System;
using MediatR;

namespace Upnodo.Features.Mood.Application.DeleteMoodRecord
{
    public class DeleteMoodRecordCommand : IRequest<DeleteMoodRecordResponse>
    {
        public DeleteMoodRecordCommand(string moodId)
        {
            MoodId = moodId;
        }
        
        public string MoodId { get; }
    }
}