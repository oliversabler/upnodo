using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.User.Application.GetLatestCreatedUsers
{
    public class GetLatestCreatedUsersResponse : BaseResponse
    {
        public GetLatestCreatedUsersResponse(bool success, object value) : base(success, value)
        {
        }
    }
}
