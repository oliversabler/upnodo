using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.User.Application.UpdateUser
{
    public class UpdateUserResponse : BaseResponse
    {
        public UpdateUserResponse(bool success, object value) : base(success, value)
        {
        }
    }
}