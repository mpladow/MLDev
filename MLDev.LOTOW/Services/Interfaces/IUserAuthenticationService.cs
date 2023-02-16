using Microsoft.AspNetCore.Identity;
using MLDev.LOTOW.DTOs;
using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.Services.Interfaces
{
    public interface IUserAuthenticationService
    {
        Task<RegisterUserResult> RegisterNewUser(UserRegistrationDto userRegistration);
    }
}
