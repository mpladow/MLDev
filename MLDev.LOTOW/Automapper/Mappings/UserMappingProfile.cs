using AutoMapper;
using MLDev.LOTOW.DTOs;
using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.Automapper.Mappings
{
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRegistrationDto, User>();
        }
    }
}
