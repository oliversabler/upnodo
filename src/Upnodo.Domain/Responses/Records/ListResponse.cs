using System.Collections.Generic;
using Upnodo.Domain.Contracts;

namespace Upnodo.Domain.Responses.Records
{
    public class ListResponse : IResponse
    {
        private IEnumerable<string> Records { get; set; }
    }
}