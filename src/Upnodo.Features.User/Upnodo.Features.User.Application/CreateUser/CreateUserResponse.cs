using Upnodo.BuildingBlocks.Application.Contracts;

namespace Upnodo.Features.User.Application.CreateUser
{
    public class CreateUserResponse : BaseResponse
    {
        public CreateUserResponse(bool success, object value) : base(success, value)
        {
        }
    }
}