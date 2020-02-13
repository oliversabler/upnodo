using System;
using MediatR;

namespace Upnodo.Modules.Records.Application
{
    public class ListQuery : IRequest<ListResponse>
    {
        private Guid guid { get; set; }
    }
}