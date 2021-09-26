using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.User.Application.DeleteAllUsers
{
    public class DeleteAllUsersResponse : BaseResponse
    {
        public DeleteAllUsersResponse(bool success) : base(success)
        {
        }
    }
}
