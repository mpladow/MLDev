using MLDev.AuthSystem.DTOs;

namespace MLDev.AuthSystem.Repositories.Interfaces
{
    public interface IUserAuthenticationRepository
    {
        Task<RegisterUserResult> RegisterUserAsync(UserRegistrationDto userForRegistration);
        Task<UserLoginResultDto> LoginAsync(UserLoginDto user);
    }
}
