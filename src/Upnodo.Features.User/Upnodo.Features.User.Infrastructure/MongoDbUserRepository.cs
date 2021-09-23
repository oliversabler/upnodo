using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System.Text.Json;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.User.Infrastructure.Dtos;

namespace Upnodo.Features.User.Infrastructure
{
    public class MongoDbUserRepository
    {
        private readonly IMongoCollection<UserDto> _users;
        private readonly ILogger<MongoDbUserRepository> _logger;

        public MongoDbUserRepository(
            IMongoDbSettings settings,
            ILogger<MongoDbUserRepository> logger)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);

            _users = db.GetCollection<UserDto>(settings.UsersCollectionName);
            _logger = logger;
        }

        public async Task<string> CreateAsync(UserDto user)
        {
            _logger.LogTrace(
                $"{nameof(CreateAsync)} in {nameof(MongoDbUserRepository)} running. " +
                $"Creating {nameof(user)} body: {JsonSerializer.Serialize(user)}");

            await _users.InsertOneAsync(user);

            return user.UserId;
        }

        public void Delete(string userId)
        {
            var deleteFilter = Builders<Domain.User>.Filter.Eq(nameof(userId), userId);

            //_users.DeleteOne(deleteFilter);
        }

        public Domain.User Update(string userId, Domain.User user)
        {
            var filter = Builders<Domain.User>.Filter.Eq(nameof(userId), userId);
            var update = Builders<Domain.User>.Update
                //.Set("alias", user.Alias)
                .Set("email", user.Email)
                .Set("firstname", user.Firstname)
                .Set("lastname", user.Lastname);

            //_users.UpdateOne(filter, update);

            return user;
        }
    }
}