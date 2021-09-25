using MediatR;

namespace Upnodo.Features.User.Application.GetLatestCreatedUsers
{
    public class GetLatestCreatedUsersQuery : IRequest<GetLatestCreatedUsersResponse>
    {
        public int TotalNumberOfUsers { get; }

        public GetLatestCreatedUsersQuery(int totalNumberOfUsers)
        {
            TotalNumberOfUsers = totalNumberOfUsers > 10 ? 10 : totalNumberOfUsers;
        }
    }
}
