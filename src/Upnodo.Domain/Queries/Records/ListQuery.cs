using System;
using MediatR;
using Upnodo.Domain.Responses.Records;

namespace Upnodo.Domain.Queries.Records
{
    public class ListQuery : IRequest<ListResponse>
    {
        private Guid guid { get; set; }
    }
}