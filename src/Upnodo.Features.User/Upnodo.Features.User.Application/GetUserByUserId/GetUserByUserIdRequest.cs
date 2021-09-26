using System.ComponentModel.DataAnnotations;
using Upnodo.BuildingBlocks.Application.Models;

namespace Upnodo.Features.User.Application.GetUserByUserId
{
    public class GetUserByUserIdRequest
    {
        [Required]
        public string UserId { get; }

        public Cache? Cache { get; }

        public GetUserByUserIdRequest(string userId, Cache cache)
        {
            UserId = userId;
            Cache = cache;
        }
    }
}
