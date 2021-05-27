namespace Upnodo.BuildingBlocks.Application.Contracts
{
    public class BaseResponse : IResponse
    {
        protected BaseResponse(bool success, object value)
        {
            Success = success;
            Value = value;
        }
        
        public bool Success { get; }
        
        public object Value { get; }
    }
}