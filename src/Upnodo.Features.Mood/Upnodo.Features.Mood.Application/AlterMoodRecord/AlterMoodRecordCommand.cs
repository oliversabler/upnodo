using System;
using MediatR;

namespace Upnodo.Features.Mood.Application.AlterMoodRecord
{
    public class AlterMoodRecordCommand : IRequest<AlterMoodRecordResponse>
    {
        public AlterMoodRecordCommand(Guid guid)
        {
            Guid = guid;
        }

        public Guid Guid { get; }
    }
}