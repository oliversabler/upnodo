using System.Collections.Generic;
using Upnodo.Domain.Contracts;

namespace Upnodo.Modules.Records.Application
{
    public class ListResponse : IResponse
    {
        private IEnumerable<string> Records { get; set; }
    }
}