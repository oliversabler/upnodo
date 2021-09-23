using System;

namespace Upnodo.Api.Middleware.Exceptions
{
    public class ServiceUnavailableException : Exception
    {
        public ServiceUnavailableException()
        {
        }

        public ServiceUnavailableException(string message)
            : base(message)
        {
        }

        public ServiceUnavailableException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}