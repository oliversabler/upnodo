namespace Upnodo.Features.Mood.Application.Contracts
{
    public class BaseResponse : IResponse
    {
        public BaseResponse(bool success)
        {
            Success = success;
        }

        public BaseResponse(bool success, string value)
        {
            Success = success;
            Value = value;
        }
        
        public bool Success { get; }
        
        public string Value { get; }
    }
}