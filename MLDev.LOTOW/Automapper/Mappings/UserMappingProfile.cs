using AutoMapper;
using MLDev.LOTOW.Data.Entities;
using MLDev.LOTOW.DTOs;
using MLDev.LOTOW.Models.Authentication;

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


        }
    }
}
