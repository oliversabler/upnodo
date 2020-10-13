namespace Upnodo.BuildingBlocks.Application.Contracts
{
    public class BaseResponse : IResponse
    {
        public BaseResponse()
        {
        }
        
        public BaseResponse(bool success)
        {
            Success = success;
        }

        // Todo: object value to json
        public BaseResponse(bool success, object value)
        {
            Success = success;
            Value = value;
        }
        
        public bool Success { get; }
        
        public object Value { get; }
    }
}