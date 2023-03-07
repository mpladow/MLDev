using MLDev.AuthSystem.DTOs;

namespace MLDev.AuthSystem.Services.Interfaces
{
    public interface IUserAuthenticationService
    {
        Task<RegisterUserResult> RegisterNewUser(UserRegistrationDto userRegistration);
        Task<UserLoginResultDto> LoginAsync(UserLoginDto userLogin);
    }
}
