using AutoMapper;
using System.Collections.Generic;
using Upnodo.Features.User.Infrastructure.Dtos;

namespace Upnodo.Features.User.Infrastructure.Mappers
{
    public static class UserMapper
    {
        private static readonly MapperConfiguration ToDtoConfig = new(cfg =>
        {
            cfg.CreateMap<Domain.User, UserDto>();
        });

        private static readonly MapperConfiguration ToModelConfig = new(cfg =>
        {
            cfg.CreateMap<UserDto, Domain.User>();
        });

        private static readonly IMapper ToDtoMapper = ToDtoConfig.CreateMapper();
        private static readonly IMapper ToModelMapper = ToModelConfig.CreateMapper();

        internal static UserDto GetDto(Domain.User user)
        {
            return ToDtoMapper.Map<UserDto>(user);
        }

        internal static Domain.User GetModel(UserDto userDto)
        {
            return ToModelMapper.Map<Domain.User>(userDto);
        }

        internal static List<Domain.User> GetModelCollection(List<UserDto> users)
        {
            return ToModelMapper.Map<List<Domain.User>>(users);
        }
    }
}
