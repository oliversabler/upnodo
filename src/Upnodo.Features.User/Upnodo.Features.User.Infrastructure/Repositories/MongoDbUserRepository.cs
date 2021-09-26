using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.User.Infrastructure.Dtos;

namespace Upnodo.Features.User.Infrastructure.Repositories
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

        public async Task DeleteAllAsync()
        {
            _logger.LogTrace($"{nameof(DeleteAllAsync)} in {nameof(MongoDbUserRepository)}. Deleting all mood records");

            await _users.DeleteManyAsync(_ => true);
        }

        public async Task DeleteAsync(string userId)
        {
            _logger.LogTrace(
                $"{nameof(DeleteAsync)} in {nameof(MongoDbUserRepository)}. " +
                $"Deleting {nameof(userId)}: {userId}");

            var deleteFilter = Builders<UserDto>.Filter.Eq(nameof(userId), userId);

            await _users.DeleteOneAsync(deleteFilter);
        }

        public async Task<List<UserDto>> ReadLatestAsync(int numberOfUsers)
        {
            _logger.LogTrace(
                $"{nameof(ReadLatestAsync)} in {nameof(MongoDbUserRepository)}. " +
                $"Reading {nameof(numberOfUsers)}: {numberOfUsers.ToString()}");

            var result = await _users.Find(_ => true)
                .SortByDescending(f => f.DateCreated)
                .Limit(numberOfUsers)
                .ToListAsync();

            return result;
        }

        public async Task<string> UpdateAsync(UserDto user)
        {
            _logger.LogTrace(
                $"{nameof(UpdateAsync)} in {nameof(MongoDbUserRepository)}. " +
                $"Updating {nameof(user)} body: {JsonSerializer.Serialize(user)}");

            var filter = Builders<UserDto>.Filter.Eq(nameof(user.UserId), user.UserId);
            var update = Builders<UserDto>.Update
                .Set(nameof(UserDto.Username), user.Username)
                .Set(nameof(UserDto.Email), user.Email)
                .Set(nameof(UserDto.Firstname), user.Firstname)
                .Set(nameof(UserDto.Lastname), user.Lastname)
                .Set(nameof(UserDto.Fullname), user.Fullname);

            await _users.UpdateOneAsync(filter, update);

            return user.UserId;
        }
    }
}