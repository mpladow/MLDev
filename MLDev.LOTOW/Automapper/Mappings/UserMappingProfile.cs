using AutoMapper;
using MLDev.AuthSystem.DTOs;
using MLDev.AuthSystem.Models.Authentication;
using MLDev.Data.Data.Entities;
using MLDev.Data.DTOs;
using MLDev.LOTOW.DTOs;

namespace MLDev.LOTOW.Automapper.Mappings
{
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRegistrationDto, User>();

            CreateMap<CharacterDto, Character>();
            //CreateMap<List<CharacterDto>, List<Character>>();
            //CreateMap<List<Character>, List<CharacterDto>>();
            CreateMap<Character, CharacterDto>();
            CreateMap<CharacterStat, CharacterStatDto>();
            CreateMap<CharacterStatDto, CharacterStat>();

            CreateMap<Stat, Stat>();
            CreateMap<Stat, StatDto>();
            CreateMap<StatDto, Stat>();
            CreateMap<StatModifier, StatModifier>();
            CreateMap<StatModifierDto, StatModifier>();
            CreateMap<StatModifier, StatModifierDto>();



        }
    }
}
