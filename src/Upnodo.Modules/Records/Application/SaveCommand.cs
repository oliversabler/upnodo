using System;
using MediatR;
using Upnodo.Domain.Enums;

namespace Upnodo.Modules.Records.Application
{
    public class SaveCommand : IRequest<SaveResponse>
    {
        public SaveCommand(Mode mode, string userId)
        {
            UserId = userId;
            Guid = Guid.NewGuid();
            Mode = mode;
            Date = DateTime.UtcNow;
        }
        
        public Guid Guid { get; }

        public DateTime Date { get; }

        public Mode Mode { get; }
        
        public string UserId { get; }
    }
}