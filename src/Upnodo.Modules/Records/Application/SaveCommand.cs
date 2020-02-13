using System;
using MediatR;
using Upnodo.Domain.Enums;

namespace Upnodo.Modules.Records.Application
{
    public class SaveCommand : IRequest<SaveResponse>
    {
        public SaveCommand(Guid guid, Mode mode, DateTime date)
        {
            Guid = guid;
            Mode = mode;
            Date = date;
        }
        
        public Guid Guid { get; }

        public Mode Mode { get; }

        public DateTime Date { get; }
    }
}