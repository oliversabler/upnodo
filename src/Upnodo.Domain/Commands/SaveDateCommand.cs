using System;
using MediatR;
using Upnodo.Domain.Enums;
using Upnodo.Domain.Responses;

namespace Upnodo.Domain.Commands
{
    public class SaveDateCommand : IRequest<SaveDateResponse>
    {
        public SaveDateCommand(Guid guid, Mode mode, DateTime date)
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