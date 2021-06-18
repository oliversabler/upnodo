using System.Collections.Generic;
using AutoMapper;
using Upnodo.Features.Mood.Domain;
using Upnodo.Features.Mood.Infrastructure.DTO;

namespace Upnodo.Features.Mood.Infrastructure.Mappers
{
    public static class MoodRecordMapper
    {
        private static readonly MapperConfiguration ToDtoConfig = new(cfg =>
        {
            cfg.CreateMap<MoodRecord, MoodRecordDto>();
            cfg.CreateMap<User, UserDto>();
        });

        private static readonly MapperConfiguration ToModelConfig = new(cfg =>
        {
            cfg.CreateMap<MoodRecordDto, MoodRecord>();
            cfg.CreateMap<UserDto, User>();
        });

        private static readonly IMapper ToDtoMapper = ToDtoConfig.CreateMapper();
        private static readonly IMapper ToModelMapper = ToModelConfig.CreateMapper();

        internal static MoodRecordDto GetDto(MoodRecord moodRecord)
        {
            return ToDtoMapper.Map<MoodRecordDto>(moodRecord);
        }

        internal static MoodRecord GetModel(MoodRecordDto moodRecord)
        {
            return ToModelMapper.Map<MoodRecord>(moodRecord);
        }

        internal static List<MoodRecord> GetModelCollection(List<MoodRecordDto> moodRecords)
        {
            return ToModelMapper.Map<List<MoodRecord>>(moodRecords);
        }
    }
}