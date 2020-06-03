using System;
using MediatR;

namespace Upnodo.Features.Mood.Application.DeleteMoodRecord
{
    public class DeleteMoodRecordCommand : IRequest<DeleteMoodRecordResponse>
    {
        public DeleteMoodRecordCommand(Guid guid)
        {
            Guid = guid;
        }
        
        public Guid Guid { get; }
    }
}