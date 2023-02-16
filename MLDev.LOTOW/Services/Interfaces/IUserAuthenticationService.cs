using Microsoft.AspNetCore.Identity;
using MLDev.LOTOW.DTOs;
using MLDev.LOTOW.Models.Authentication;
using System.Security.Claims;

namespace MLDev.LOTOW.Services.Interfaces
{
    public interface IUserAuthenticationService
    {
        Task<RegisterUserResult> RegisterNewUser(UserRegistrationDto userRegistration);
        Task<UserLoginResultDto> LoginAsync(UserLoginDto userLogin);
    }
}
