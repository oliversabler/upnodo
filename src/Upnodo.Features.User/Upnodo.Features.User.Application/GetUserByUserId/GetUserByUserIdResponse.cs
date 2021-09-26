using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.User.Application.GetUserByUserId
{
    public class GetUserByUserIdResponse : BaseResponse
    {
        public GetUserByUserIdResponse(bool success, object value) : base(success, value)
        {
        }
    }
}
