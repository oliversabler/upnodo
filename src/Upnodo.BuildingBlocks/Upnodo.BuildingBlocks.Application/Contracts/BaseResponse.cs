using Upnodo.BuildingBlocks.Application.Abstractions;

namespace Upnodo.BuildingBlocks.Application.Contracts
{
    public class BaseResponse : IResponse
    {
        public bool Success { get; }

        public object Value { get; }

        protected BaseResponse(bool success)
        {
            Success = success;
        }

        protected BaseResponse(bool success, object value)
        {
            Success = success;
            Value = value;
        }
    }
}