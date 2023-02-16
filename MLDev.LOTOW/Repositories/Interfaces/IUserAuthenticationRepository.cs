using Microsoft.AspNetCore.Identity;
using MLDev.LOTOW.DTOs;
using MLDev.LOTOW.Models;

namespace MLDev.LOTOW.Repositories.Interfaces
{
    public interface IUserAuthenticationRepository
    {
        Task<RegisterUserResult> RegisterUserAsync(UserRegistrationDto userForRegistration);
    }
}
