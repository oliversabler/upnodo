using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.User.Infrastructure.Services
{
    public class DeleteAllUsersResponse : BaseResponse
    {
        public DeleteAllUsersResponse(bool success) : base(success)
        {
        }
    }
}