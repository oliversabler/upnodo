using MongoDB.Driver;
using Upnodo.BuildingBlocks.Application.Configurations;

namespace Upnodo.Features.User.Infrastructure.Services
{
    public class UserService
    {
        private readonly IMongoCollection<Domain.User> _users;

        public UserService(IUpnodoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);

            _users = db.GetCollection<Domain.User>(settings.UsersCollectionName);
        }

        public Domain.User Create(Domain.User user)
        {
            _users.InsertOne(user);
            return user;
        }
    }
}