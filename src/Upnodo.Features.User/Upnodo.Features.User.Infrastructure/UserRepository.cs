using MongoDB.Driver;
using Upnodo.BuildingBlocks.Application.Configurations;

namespace Upnodo.Features.User.Infrastructure
{
    public class UserRepository
    {
        private readonly IMongoCollection<Domain.User> _users;

        public UserRepository(IUpnodoDatabaseSettings settings)
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

        public void Delete(string userId)
        {
            var deleteFilter = Builders<Domain.User>.Filter.Eq("userId", userId);
            
            _users.DeleteOne(deleteFilter);
        }
    }
}