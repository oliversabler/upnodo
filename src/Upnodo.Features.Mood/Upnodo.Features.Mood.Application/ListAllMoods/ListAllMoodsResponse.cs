using Upnodo.Domain.Contracts;

namespace Upnodo.Features.Mood.Application.ListAllMoods
{
    public class ListAllMoodsResponse : IResponse
    {
        public ListAllMoodsResponse(bool success, string value)
        {
            Success = success;
            Value = value;
        }
        
        public bool Success { get; }
        
        public string Value { get; }
    }
}