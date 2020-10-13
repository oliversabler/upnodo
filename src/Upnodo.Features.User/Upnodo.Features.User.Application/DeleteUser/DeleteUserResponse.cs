using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.User.Application.DeleteUser
{
    public class DeleteUserResponse : BaseResponse
    {
        public DeleteUserResponse(bool success) : base(success)
        {
        }
    }
}