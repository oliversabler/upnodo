using System.Text.Json;

namespace Upnodo.Api.Middleware.Exceptions
{
    public class GlobalExceptionDetails
    {
        public GlobalExceptionDetails(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
        
        public int StatusCode { get; }

        public string Message { get; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}