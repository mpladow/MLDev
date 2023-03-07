using MLDev.AuthSystem.DTOs;
using MLDev.AuthSystem.Repositories.Interfaces;
using MLDev.AuthSystem.Services.Interfaces;
using MLDev.LOTOW.DTOs;

namespace MLDev.AuthSystem.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private IUserAuthenticationRepository _repository;

        public UserAuthenticationService(IUserAuthenticationRepository repository)
        {
            _repository = repository;
        }


        public Task<RegisterUserResult> RegisterNewUser(UserRegistrationDto userRegistration)
        {
            return _repository.RegisterUserAsync(userRegistration);
        }

        public Task<UserLoginResultDto> LoginAsync(UserLoginDto userLogin)
        {
            return _repository.LoginAsync(userLogin);
        }

    }
}
