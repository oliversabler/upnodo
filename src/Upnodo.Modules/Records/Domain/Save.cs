using System;
using Upnodo.Domain.Enums;

namespace Upnodo.Modules.Records.Domain
{
    public class Save
    {
        public Save(Guid guid, Mode mode)
        {
            Guid = guid;
            Date = DateTime.UtcNow;
            Mode = mode;
        }

        private Guid Guid { get; }

        private DateTime Date { get; }

        private Mode Mode { get; }
    }
}