using System;
using MediatR;

namespace Upnodo.Features.Mood.Application.AlterMoodRecord
{
    public class AlterMoodRecordCommand : IRequest<AlterMoodRecordResponse>
    {
        public AlterMoodRecordCommand(Guid guid, Domain.Mood mood)
        {
            Guid = guid;
            Mood = mood;
        }

        public Guid Guid { get; }
        
        public Domain.Mood Mood { get; }
    }
}