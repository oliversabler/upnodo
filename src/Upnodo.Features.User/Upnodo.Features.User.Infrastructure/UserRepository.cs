using MongoDB.Driver;
using Upnodo.BuildingBlocks.Application.Abstractions;

namespace Upnodo.Features.User.Infrastructure
{
    public class UserRepository
    {
        private readonly IMongoCollection<Domain.User> _users;

        public UserRepository(IMongoDbSettings settings)
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
            var deleteFilter = Builders<Domain.User>.Filter.Eq(nameof(userId), userId);
            
            _users.DeleteOne(deleteFilter);
        }

        public Domain.User Update(string userId, Domain.User user)
        {
            var filter = Builders<Domain.User>.Filter.Eq(nameof(userId), userId);
            var update = Builders<Domain.User>.Update
                .Set("alias", user.Alias)
                .Set("email", user.Email)
                .Set("firstname", user.Firstname)
                .Set("lastname", user.Lastname);
            
            _users.UpdateOne(filter, update);

            return user;
        }
    }
}