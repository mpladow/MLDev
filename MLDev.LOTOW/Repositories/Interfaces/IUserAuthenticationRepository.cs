using Microsoft.AspNetCore.Identity;
using MLDev.LOTOW.DTOs;
using MLDev.LOTOW.Models.Authentication;
using System.Security.Claims;

namespace MLDev.LOTOW.Repositories.Interfaces
{
    public interface IUserAuthenticationRepository
    {
        Task<RegisterUserResult> RegisterUserAsync(UserRegistrationDto userForRegistration);
        Task<UserLoginResultDto> LoginAsync(UserLoginDto user);
    }
}
